using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication1
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var server = HttpContext.Current.Server;
            var exception = server.GetLastError();
            var request = HttpContext.Current.Request;
            var url = "http://" + request.Headers["host"] + request.RawUrl;

            var msg = String.Format("{0} Url:{1}\r\n{2}, \r\nUserAgent:{3}", DateTime.UtcNow, url, exception, request.UserAgent);

            using (StreamWriter sw = new StreamWriter(Server.MapPath("~/app_data/log.txt"), true))
            {
                sw.WriteLine(msg);
            }

        }
    }
}
