using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webserver.Server.Parsers
{
    public enum HttpMethod
    {
        Get,
        Post
    }

    class HttpRequest
    {
        public readonly HttpMethod HttpMethod;

        public readonly string Controller;

        public readonly string Method;

        public readonly IDictionary<string, string> MessageHeaders;

        public readonly string EntityBody;

        public readonly bool IsFile;

        public readonly string Path;

        public readonly string FileType;

        public HttpRequest(string requsetText)
        {

            MessageHeaders = new Dictionary<string, string>();
            var lines = requsetText.Split('\n');
            var words = lines[0].Split(' ');
            Path = words[1].Remove(0,1);
            if (words[1].Contains('.'))
            {
                var splitted = words[1].Split('.');
                string fileTypeGot = splitted[1];
                switch (fileTypeGot)
                {
                    case "js": FileType = "text/javascript"; break;
                    case "css": FileType = "text/" + fileTypeGot; break;
       
                }
                IsFile = true;
            }
            else
            {
                IsFile = false;
            }

            switch (words[0])
            {
                case "GET": HttpMethod = HttpMethod.Get;
                    break;
                case "POST": HttpMethod = HttpMethod.Post;
                    break;
                default:
                    throw new Exception("Данный HTTP метод не поддерживается");
            }
            var slog = words[1].Split('/');
            if (slog[1] == "")
            {
                Controller = "Home";
                Method = "Index";
            }
            else if (slog.Length < 3 || slog[2] == "")
            {
                Controller = slog[1];
                Method = "Index";
            }
            else
            {
                Controller = slog[1];
                Method = slog[2];
            }
            int i;

            //Плиз сделай проще
            for (i = 1; lines[i] != "\r"; i++)
            {
                var splitted = lines[i].Split(':');
                splitted[1] = splitted[1].Split(' ')[1];
                string value = splitted[1];
                for (int j = 2; j < splitted.Length; j++)
                {
                    value += ":" + splitted[j];
                }
                MessageHeaders.Add(splitted[0], value = value.Split('\r')[0]);

            }
            EntityBody = "";
            for (++i; i < lines.Length; i++)
            {
                EntityBody += lines[i];
            }

        }

    }
}

