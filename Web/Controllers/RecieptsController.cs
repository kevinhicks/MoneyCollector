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
using System.Web.Mvc;

namespace Web.Controllers
{
    [RoutePrefix("api")]
    public class RecieptsController : ApiController
    {
        [GET("Reciepts")]
        public Reciept[] GetReciepts()
        {
            return new RecieptManager().GetAllReciepts().ToArray();
        }

        [GET("Reciept/{id:guid}")]
        public Reciept GetReciept(Guid ID)
        {
            return new RecieptManager().GetReciept(ID);
        }

        [POST("Reciept")]
        public HttpResponseMessage AddReciept(Reciept reciept)
        {
            var response = Request.CreateResponse<Reciept>(HttpStatusCode.Created, reciept);            
            return response;
        }

        [PUT("Reciept/{id:guid}")]
        public HttpResponseMessage UpdateReciept(Guid ID, Reciept reciept)
        {
            var response = Request.CreateResponse<Reciept>(HttpStatusCode.NoContent, reciept);
            return response;
        }

        [DELETE("Reciept/{id:guid}")]
        public HttpResponseMessage RemoveReciept(Guid ID)
        {
            var response = Request.CreateResponse(HttpStatusCode.NoContent);
            return response;
        }
    }
}