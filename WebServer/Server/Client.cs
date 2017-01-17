using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Webserver.Server.Parsers;
using WebServer.Server.Connector;
using WebServer.Controllers;

namespace WebServer.Server
{
    class Client
    {
        public Client(TcpClient client)
        {
            byte[] Buffer = new byte[1024];
            int count;
            string request = String.Empty;
            while ((count = client.GetStream().Read(Buffer, 0, Buffer.Length)) > 0)
            {
                request += Encoding.UTF8.GetString(Buffer, 0, count);
                if (request.IndexOf("\r\n\r\n") >= 0 || request.Length > 4096)
                {
                    break;
                }
            }
            if (!string.IsNullOrEmpty(request))
            {
                var request2 = new HttpRequest(request);
                string Str = (string)MethodConnector.Invoke(request2);
                Console.WriteLine(request);

                byte[] WriteBuffer = Encoding.UTF8.GetBytes(Str);

                client.GetStream().Write(WriteBuffer, 0, WriteBuffer.Length);
                // Закроем соединение
            }
            client.Close();
        }
    }
}
