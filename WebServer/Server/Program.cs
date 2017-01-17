using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebServer.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            int MaxThreadsCount = Environment.ProcessorCount * 100;
            ThreadPool.SetMaxThreads(MaxThreadsCount, MaxThreadsCount);
            ThreadPool.SetMinThreads(2, 2);
            new Server(8080);
        }
    }
}
