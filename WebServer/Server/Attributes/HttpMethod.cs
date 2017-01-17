using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webserver.Server.Parsers;

namespace WebServer.Server.Attributes
{
    class HttpMethodAttribute : Attribute
    {
        public HttpMethod Method;
        public HttpMethodAttribute(HttpMethod method)
        {
             Method = method;
        }
    }
}
