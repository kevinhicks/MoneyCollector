using AttributeRouting;
using AttributeRouting.Web.Http;
using Data.Model;
using Data.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Web.Controllers
{
    [RoutePrefix("api")]
    public class RecieptsController : ApiController
    {
        [GET("ListReciepts")]
        public Reciept[] GetReciepts()
        {
            return new RecieptManager().GetAllReciepts().ToArray();
        }
    }
}