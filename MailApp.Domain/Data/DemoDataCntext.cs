using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailApp.Domain.Models;

namespace MailApp.Domain.Data
{
    public class DemoDataContext
    {
        #region Properites
        public ObservableCollection<User> Users { get; set; }
        public ObservableCollection<Mail> Mails { get; set; }
        #endregion
        #region CTOR
        public DemoDataContext()
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            Users = new ObservableCollection<User>
        {
            new User { ID = Guid.NewGuid(), Username = "John Doe", Email = "johndoe@example.com", ImagePath=baseDirectory + @"Assets/photo1.jfif" },
            new User { ID = Guid.NewGuid(), Username = "Jane Doe", Email = "janedoe@example.com", ImagePath = baseDirectory + @"Assets/photo2.jfif" },
            new User { ID = Guid.NewGuid(), Username = "Bob Smith", Email = "bobsmith@example.com", ImagePath = baseDirectory + @"Assets/photo3.jpg" },
            new User { ID = Guid.NewGuid(), Username = "Alice Smith", Email = "alicesmith@example.com", ImagePath = baseDirectory + @"Assets/photo4.jpg" }
        };

            Mails = new ObservableCollection<Mail>
        {
            new Mail
            {
                ID = Guid.NewGuid(),
                Date = DateTime.Now.AddDays(-1),
                Subject = "Meeting Reminder",
                Content = "Just a reminder that we have a meeting at 2pm today.",
                UserId = Users[0].ID,
                User = Users[0]
            },
            new Mail
            {
                ID = Guid.NewGuid(),
                Date = DateTime.Now.AddDays(-2),
                Subject = "New Product Release",
                Content = "We've just released a new product, check it out!",
                UserId = Users[1].ID,
                User = Users[1]
            },
            new Mail
            {
                ID = Guid.NewGuid(),
                Date = DateTime.Now.AddDays(-3),
                Subject = "Team Building Event",
                Content = "Our next team building event is scheduled for next Friday.",
                UserId = Users[2].ID,
                User = Users[2]
            },
            new Mail
            {
                ID = Guid.NewGuid(),
                Date = DateTime.Now.AddDays(-4),
                Subject = "Holiday Schedule",
                Content = "Our holiday schedule has been posted, please take a look.",
                UserId = Users[3].ID,
                User = Users[3]
            }
        };
        }
        #endregion
    }
}
