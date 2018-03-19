using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication9.callsbl;
using WebApplication9.Models;

namespace WebApplication9.Controllers
{
    public class callsController : ApiController
    {
        [HttpGet]
        [ActionName("Getcalls")]
        //public List<calls> Getcalls(string user, string category, string speciality)
        public List<calls> Getcalls(string k1, string k2, string k3,string v1,string v2,string v3)
        {
            callbl a = new callbl();
            return a.Getcalls(k1, k2, k3,v1,v2,v3);
        }
    }
}
