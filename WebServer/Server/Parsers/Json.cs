using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webserver.Server.Parsers
{
    class Json
    {
        public readonly IDictionary<string, string> variables;
        public Json(string jsonText)
        {
            //Паринг json
        }

        public Json(IDictionary<string, string> variables)
        {
            this.variables = variables;
        }

        //TODO: массивы, вложенные структуры(скорее всего не нужно, т.к они уже парсятся в json и все будет рекурсивно делаться правильно)
        public override string ToString()
        {
            string json = "{";
            foreach(var key in variables.Keys)
            {
                if(json.Length > 1)
                    json+=",";
                string value;
                variables.TryGetValue(key, out value);
                json += "\"" + key + "\":" + "\"" + value + "\"";
            }
            json += "}";
            return json;
        }
    }
}
