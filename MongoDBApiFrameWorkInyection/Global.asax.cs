using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDBApiFrameWorkInyection.Controllers;
using MongoDBApiFrameWorkInyection.Models;
using MongoDBApiFrameWorkInyection.Services;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MongoDBApiFrameWorkInyection
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        public IServiceProvider ServiceProvider { get; set; }
        public ServiceCollection Services { get; set; }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            InitializeServices();
        }


        public void InitializeServices()
        {
            // Configuración y servicios de Web API
            Services = new ServiceCollection();

            PeopleSettings settings = new PeopleSettings();
            NameValueCollection section = (NameValueCollection)ConfigurationManager.GetSection(nameof(PeopleSettings));
            settings.Server = section["Server"];
            settings.Database = section["Database"];
            settings.Collection = section["Collection"];

            Services.AddSingleton<ISettings>(settings);
            Services.AddSingleton<IMongoClient, MongoClient>(c =>
            {
                var uri = settings.Server;
                return new MongoClient(uri);
            });
            Services.AddSingleton<IServices, PeopleService>();
            Services.AddTransient(typeof(PeopleController));

            ServiceProvider = Services.BuildServiceProvider();

            var defaultResolver = new DefaultDependencyResolver(ServiceProvider);
            DependencyResolver.SetResolver(defaultResolver);
        }
    }
}
