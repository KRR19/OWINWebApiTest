using System.Web.Http;
using Owin;
namespace  OWINWebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Use(typeof(LoggerModule), "OwinLogger: ");
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute("default", "{controller}");
            app.UseWebApi(config);
        }
    }
}