using AlfaCar43Project.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace AlfaCar43Project.Components
{
    /// <summary>
    /// Базовый класс отправки письма на почту
    /// </summary>
    public abstract class SendEmailsBase
    {
        /// <summary>
        /// Отправка письма на почту
        /// </summary>
        /// <param name="model"></param>
        public abstract void SendEmail(FeedbackViewModel model);

    }
}