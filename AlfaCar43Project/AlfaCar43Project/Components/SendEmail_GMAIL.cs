using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using AlfaCar43Project.Models;

namespace AlfaCar43Project.Components
{
    /// <summary>
    /// Компонент отправка письма на почту через провайдер GMAIL
    /// </summary>
    public class SendEmail_GMAIL : SendEmailsBase
    {
        public override void SendEmail(FeedbackViewModel model)
        {
            var client = new SmtpClient("smtp.gmail.com", 587);
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
    }
}
