using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class Reciept
    {
        [Key]
        public Guid ID { get; set; }
        public DateTime Date { get; set; }
        public float WorldWideWork { get; set; }
        public float Congregation { get; set; }
        public float KingdomHallFund { get; set; }
        public float Miscellaneous1 { get; set; }
        public float Miscellaneous2 { get; set; }

        public string Miscellaneous1Name { get; set; }
        public string Miscellaneous2Name { get; set; }

        /// <summary>
        /// ctor
        /// </summary>
        public Reciept()
        {
            ID = Guid.NewGuid();
            Date = DateTime.Now;
            WorldWideWork = 0;
            Congregation = 0;
            KingdomHallFund = 0;
            Miscellaneous1 = 0;
            Miscellaneous2 = 0;
            Miscellaneous1Name = "";
            Miscellaneous2Name = "";
        }
    }
}
