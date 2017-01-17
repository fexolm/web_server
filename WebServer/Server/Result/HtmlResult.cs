using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webserver.Server.Parsers;

namespace WebServer.Server.Result
{
    class HtmlResult : BaseResult
    {
        public HtmlResult(string path) : base(path, "text/html") { }
    }
}
