using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwinConsole
{
    using System.IO;
    using System.Web.Http;
    using Microsoft.Owin.Hosting;
    using Owin;
    using AppFunc = Func<IDictionary<string, object>, Task>;

    public class Program
    {
        static void Main(string[] args)
        {
            string uri = "http://localhost:8080";

            using (WebApp.Start<Startup>(uri))
            {
                Console.WriteLine("Started !!");
                Console.ReadKey();
                Console.WriteLine("Stopped !!");
            }
        }
    }

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // To add a default welcome page
            // app.UseWelcomePage();

            // Other way to write middleware
            //app.Use(async (environment, next) =>
            //{
            //   foreach (var env in environment.Environment)
            //   {
            //       Console.WriteLine("{0}:{1}", env.Key, env.Value);
            //   }

            //   await next();
            //});

            app.Use(async (environment, next) =>
            {
                Console.WriteLine("Request Path: " + environment.Request.Path);

                await next();

                Console.WriteLine("Response Status: " + environment.Response.StatusCode);
            });

            ConfigureWebApi(app);

            app.UseHelloWorld();
        }

        private void ConfigureWebApi(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                "DefaultApi",
                "api/{controller}/{id}",
                new { id = RouteParameter.Optional }
                );
            app.UseWebApi(config);
        }
    }

    // To allow for syntactic sugar
    public static class AppBuilderExtensions
    {
        public static void UseHelloWorld(this IAppBuilder app)
        {
            // This code can directly be used in startup configuration
            app.Use<HelloWorldComponent>();
        }
    }

    // Owin component
    public class HelloWorldComponent
    {
        AppFunc _next;
        public HelloWorldComponent(AppFunc next)
        {
            this._next = next;
        }

        public Task Invoke(IDictionary<string, object> environment)
        {
            var response = environment["owin.ResponseBody"] as Stream;
            using (var writer = new StreamWriter(response))
            {
                return writer.WriteAsync("Hello World !");
            }
        }
    }
}

