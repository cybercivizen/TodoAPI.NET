using System.Web.Http;

namespace API.NET {
    public static class WebApiConfig {
        public static void Register(HttpConfiguration config) {
            // Configuration et services API Web
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            // Itinéraires de l'API Web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "UserTasks",
                routeTemplate: "api/users/{id}/tasks",
                defaults: new { controller = "Users", action = "GetTasksByUser" }
            );
        }
    }
}
