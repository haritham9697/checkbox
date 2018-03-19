using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication9.callsdl;
using WebApplication9.Models;

namespace WebApplication9.callsbl
{
    public class callbl
    {
        public List<calls> Getcalls(string user, string category, string speciality,string v1,string v2,string v3)
        {
            calldl a = new calldl();
            return a.Getcalls(user, category, speciality,v1,v2,v3);
        }
    }
}