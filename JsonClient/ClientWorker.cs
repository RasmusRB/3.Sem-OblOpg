using System;
using System.IO;
using System.Net.Sockets;
using CykelLib;
using Newtonsoft.Json;

namespace JsonClient
{
    internal class ClientWorker
    {
        private const int SERVER_PORT = 4646;

        public ClientWorker()
        {

        }

        internal void Start()
        {
            TcpClient socket = new TcpClient("localhost", SERVER_PORT);
            using (StreamWriter sw = new StreamWriter(socket.GetStream()))
            {
                sw.AutoFlush = true;

                Cykel cykel = new Cykel(1, "blå", 999.99, 16);

                string json = JsonConvert.SerializeObject(cykel);

                sw.WriteLine(json);
            }
            socket.Close();
        }
    }
}