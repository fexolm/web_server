using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebServer.Server
{
    class Server
    {
        TcpListener Listener;
        public Server(int port)
        {
            Listener = new TcpListener(IPAddress.Any, port);
            Listener.Start();
           
            while(true)
            {
                ThreadPool.QueueUserWorkItem(ClientThread, Listener.AcceptTcpClient());
            }
        }
        void ClientThread(Object StateInfo)
        {
            //Console.Clear();
            new Client((TcpClient)StateInfo);
        }
        ~Server()
        {
            // Если "слушатель" был создан
            if (Listener != null)
            {
                // Остановим его
                Listener.Stop();
            }
        }
    }
}
