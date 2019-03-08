using AlfaCar43Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace AlfaCar43Project.Controllers
{
    //Бэкенд для раздела "Связаться с нами"
    public class FeedbackController : Controller
    {
        // GET: Связаться с нами
        [HttpGet]
        public ActionResult SendEmail()
        {
            return View();
        }

        //POST: Связаться с нами
        [HttpPost]
        public ActionResult SendEmail(FeedbackViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var client = new SmtpClient("smtp.gmail.com", 587))
            {
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential("sp4002.04.03.2016@gmail.com", "podVYXaRuwoW");
                var mail = new MailMessage();
                mail.From = new MailAddress("sp4002.04.03.2016@gmail.com");
                mail.To.Add("dmbsseller@gmail.com");
                mail.Subject = string.Format("Вы получили письмо от посетителя сайта {0} c номером телефона {1}. Пора позвонить ему!", model.Name, model.Phone);
                mail.Body = model.Message;
                if (model.Attachment != null && model.Attachment.ContentLength > 0)
                {
                    var attachment = new Attachment(model.Attachment.InputStream, model.Attachment.FileName);
                    mail.Attachments.Add(attachment);
                }
                client.Send(mail);
            }
            TempData["Success"] = "Ваше сообщение успешно отправлено!";
            return RedirectToAction("Index", "Home");
        }

        public ActionResult SuccessSend()
        {
            return View();
        }
    }
}