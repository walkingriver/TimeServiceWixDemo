using System;
using System.Web.Http;
using System.Web.Http.SelfHost;
using log4net;

namespace TimeService
{
    public class TimeServiceAdapter : IDisposable
    {
        private HttpSelfHostServer server;
        private static readonly ILog Logger = LogManager.GetLogger(typeof(TimeServiceAdapter));

        public void Start()
        {
            Logger.Debug("Starting service adapter.");
            var config = new HttpSelfHostConfiguration("http://localhost:8080");

            config.Routes.MapHttpRoute(
                "API Default", "api/{controller}/{action}/{id}",
                new { id = RouteParameter.Optional, controller = "Time", action = "Index" });

            server = new HttpSelfHostServer(config);

            Logger.Debug("Opening self host server.");
            server.OpenAsync();
        }

        public void Stop()
        {
            Logger.Debug("Closing self host server.");
            server.CloseAsync().Wait();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing || server == null) return;
            Logger.Debug("Disposing self host server.");
            server.Dispose();
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
