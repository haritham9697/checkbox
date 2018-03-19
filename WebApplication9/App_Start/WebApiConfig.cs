using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;

namespace WebApplication9
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{k1}/{k2}/{k3}/{v1}/{v2}/{v3}",
                defaults: new { k1 = RouteParameter.Optional, k2 = RouteParameter.Optional, k3 = RouteParameter.Optional, v1 = RouteParameter.Optional, v2 = RouteParameter.Optional, v3 = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
               name: "Getcalls",
               routeTemplate: "api/calls/{k1}/{k2}/{k3}/{v1}/{v2}/{v3}",
               defaults: new { controller = "calls", action = "Getcalls" }
           );
        }
    }
}
