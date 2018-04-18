using LoymaxTestTask.Models;
using System.Data.Entity;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace LoymaxTestTask
{
    public class WebApiApplication : System.Web.HttpApplication
    {
         protected void Application_Start()
        {
            //Database.SetInitializer(new PersonDbInitializer());
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            Bot.Get();
            
           
        }
    }
}
