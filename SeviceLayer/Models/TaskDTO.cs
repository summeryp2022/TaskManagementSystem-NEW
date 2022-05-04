using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeviceLayer.Models
{
    public class TaskDTO
    {
        public int QuoteID { get; set; }
        public string QuoteType { get; set; }
        public string Contact { get; set; }
        public string Task1 { get; set; }
        public Nullable<System.DateTime> DueDate { get; set; }
        public string TaskType { get; set; }
    }
}
