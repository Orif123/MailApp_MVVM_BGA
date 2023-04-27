using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailApp.Domain.Interface
{
    public interface IEntityWithId
    {
        Guid ID { get; set; }
    }
}
