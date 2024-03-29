﻿using System.Web.Mvc;
using System.Web.Routing;

namespace MVCKurumsalSiteProje
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes(); // actionlara özel sayfa adresi tanımlamamız için
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new[] { "MVCKurumsalSiteProje.Controllers" }
            );
        }
    }
}
