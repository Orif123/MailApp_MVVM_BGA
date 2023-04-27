using MailApp.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailApp.Models.Models
{
    public class Mail : IEntityWithId
    {
        public Guid ID { get; set; }
        public DateTime Date { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
