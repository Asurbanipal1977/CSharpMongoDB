using System.Web.Http;

namespace MongoDBApiFrameWorkInyection
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Rutas de Web API
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

       
    }
}
