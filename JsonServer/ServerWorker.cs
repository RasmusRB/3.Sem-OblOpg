using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using CykelLib;
using Newtonsoft.Json;

namespace JsonServer
{
    internal class ServerWorker
    {
        private const int PORT = 4646;

        private static List<Cykel> _cykler = new List<Cykel>()
        {
            new Cykel(1, "blå", 1999.99, 16),
            new Cykel(2, "sort", 2999.99, 20),
            new Cykel(3, "grøn", 4999.99, 18),
            new Cykel(4, "grå", 9999.99, 32),
            new Cykel(5, "rød", 4599.99, 16)
        };

        public ServerWorker()
        {

        }

        internal void Start()
        {
            TcpListener server = new TcpListener(IPAddress.Loopback, PORT);
            server.Start();

            while (true)
            {
                TcpClient socket = server.AcceptTcpClient();
                Task.Run(
                    () =>
                    {
                        TcpClient tmpSocket = socket;
                        DoClient(tmpSocket);
                    }
                );
            }
        }

        private void DoClient(TcpClient socket)
        {
            using (StreamReader sr = new StreamReader(socket.GetStream()))
            using (StreamWriter sw = new StreamWriter(socket.GetStream()))
            {
                sw.AutoFlush = true;

                string cykelString = sr.ReadLine();

                Cykel cykel = JsonConvert.DeserializeObject<Cykel>(cykelString);

                Console.WriteLine("Received cykel json string " + cykelString);
                Console.WriteLine("Received cykel : " + cykel);
            }
            socket.Close();
        }
    }
}