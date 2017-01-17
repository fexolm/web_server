using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webserver.Server.Parsers
{
    sealed class HttpResponse
    {
        private readonly string Text;

        public HttpResponse(bool success, int status, string message, string type)
        {
            Text = "HTTP/1.1 " + status + (success ? " OK":"") + "\nAccess-Control-Allow-Origin: *\n" + "Content-type: " + type + "\nContent-Length:" +Encoding.UTF8.GetByteCount(message)+ "\n\n" + message;
        }


        public override string ToString()
        {
            return Text;
        }
    }
}
