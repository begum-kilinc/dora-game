using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game.Models
{
    public class Logs
    {
        public int ID { get; set; }
        public int RecordCount { get; set; }

        public DateTime RecordDate { get; set; }


    public string RecordMessage {get; set;}
    }
}
