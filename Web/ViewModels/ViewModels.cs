using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.ViewModels
{
    public class HistoryViewModel
    {
        public List<Reciept> Reciepts { get; set; }
    }

    public class NewRecieptViewModel
    {
        public Reciept Reciept { get; set; }
    }
}
