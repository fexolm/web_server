using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webserver.Server.Parsers;

namespace WebServer.Server.Interfaces
{
    interface IJsonConvertable
    {
        Json ToJson();
    }
}
