using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;

namespace MoneyCollecter.Models
{
    public class CollectorDB : DbContext
    {
        public CollectorDB()
            : base("DefaultConnection")
        {
        }

        public DbSet<Reciept> Reciepts { get; set; }
    }

    public class Reciept
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [DataType(DataType.Currency)]
        public float? WorldWideWork { get; set; }

        [DataType(DataType.Currency)]
        public float? KingdomHallFund { get; set; }

        [DataType(DataType.Currency)]
        public float? Congregation { get; set; }

        [DataType(DataType.Currency)]
        public float? Misc1 { get; set; }
        public string Misc1Name { get; set; }

        [DataType(DataType.Currency)]
        public float? Misc2 { get; set; }
        public string Misc2Name { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}
