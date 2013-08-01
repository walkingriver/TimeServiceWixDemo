using System;
using System.Configuration;
using System.Web.Http;

namespace TimeService
{
    public class TimeController: ApiController
    {
        private String dateFormat = "s";
        public TimeController()
        {
            dateFormat = ConfigurationManager.AppSettings["dateFormat"] ?? "s";
        }

        [HttpGet]
        public String Index()
        {
            return DateTime.Now.ToString(dateFormat);
        }
    }
}
