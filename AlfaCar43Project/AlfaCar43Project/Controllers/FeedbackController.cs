using AlfaCar43Project.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
                client.Credentials = new NetworkCredential("alfacar43@gmail.com", "ae2485370");
                var mail = new MailMessage();
                mail.From = new MailAddress("alfacar43@gmail.com");
                mail.To.Add("alfacar43@gmail.com");
                mail.Subject = string.Format("Вы получили письмо от посетителя сайта {0} c номером телефона {1}. Пора позвонить ему!", model.Name, model.Phone);
                mail.Body = model.Message;
                foreach (HttpPostedFileBase attachment in model.Attachments)
                {
                    if (attachment != null && attachment.ContentLength > 0)
                    {
                        string fileName = Path.GetFileName(attachment.FileName);
                        mail.Attachments.Add(new Attachment(attachment.InputStream, fileName));
                    }
                }

                client.Send(mail);
            }
            TempData["Success"] = "Ваше сообщение успешно отправлено!";
            return RedirectToAction("Index", "Home");
        }

    }
}