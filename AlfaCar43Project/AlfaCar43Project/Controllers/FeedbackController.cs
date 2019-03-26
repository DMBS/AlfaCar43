using AlfaCar43Project.Models;
using AlfaCar43Project.Components;
using System;
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
            if (ModelState.IsValid)
            {
                try
                {
                    SendEmail_GMAIL o = new SendEmail_GMAIL();
                    o.SendEmail(model);
                    ModelState.Clear();
                    TempData["Success"] = "Ваше сообщение успешно отправлено!";
                }

                catch (Exception)
                {
                    ModelState.Clear();
                    TempData["Danger"] = "В ходе отправки сообщения произошла ошибка!";
                }
            }

            return RedirectToAction("Index", "Home");
        }

    }   
}
