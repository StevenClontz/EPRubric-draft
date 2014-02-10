using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Text.RegularExpressions;

namespace EPRubric
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
        }

        // Sets up rewrite rule to force lowercase before the GET query string
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            string url = Request.Url.ToString();
            if (Request.HttpMethod == "GET" && Regex.Match(url, "(?<=^[^?]*)[A-Z]").Success)
            {
                Response.RedirectPermanent(url.ToLower(), true);
            }
        }
    }
}