using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AlfaCar43Project.Models
{
    public class FeedbackViewModel
    {
        //имя пользователя
        [Required]
        public string Name { get; set; }

        //телефон пользователя
        [Required]
        public string Phone { get; set; }

        //сообщение
        [Required]
        public string Message { get; set; }

        //прилагаемые файлы
        public List<HttpPostedFileBase> Attachments { get; set; }
    }
}