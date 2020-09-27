using System;

namespace JsonServer
{
    class Program
    {
        static void Main(string[] args)
        {
            ServerWorker worker = new ServerWorker();
            worker.Start();

            Console.ReadLine();
            Console.ReadLine();
        }
    }
}
