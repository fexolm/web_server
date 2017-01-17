using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webserver.Server.Parsers;

namespace WebServer.Server.Result
{
    class BaseResult
    {
        protected HttpResponse response;
        public BaseResult(string path, string type)
        {

            try
            {
                using (var sr = new StreamReader(path))
                {
                    response = new HttpResponse(true, 200, sr.ReadToEnd(), type);
                    sr.Close();
                }
            }
            catch (Exception ex)
            {
                response = new HttpResponse(false, 400, ex.ToString(), "text");
            }

        }

        public override string ToString()
        {
            return response.ToString();
        }
    }
    
}
