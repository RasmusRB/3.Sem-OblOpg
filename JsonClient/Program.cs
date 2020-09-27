using System;

namespace JsonClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ClientWorker worker = new ClientWorker();
            worker.Start();

            Console.ReadLine();
        }
    }
}
