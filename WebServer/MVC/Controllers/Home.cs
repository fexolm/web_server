using Webserver.Server.Parsers;
using WebServer.Server.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServer.Server.Result;

namespace WebServer.Controllers
{
    static class Home
    {
        [HttpMethod(HttpMethod.Get)]
        public static HtmlResult Index()
        {
            return new HtmlResult("MVC/View/Home/Index.html");
        }

        [HttpMethod(HttpMethod.Get)]
        public static HtmlResult Nastya()
        {
            return new HtmlResult("MVC/View/Home/Nastya.html");
        }

    }
}
