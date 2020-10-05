using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        // const port nr
        private const int PORT = 4646;

        // statisk liste til data
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

            while (true) // håndtere flere klienter
            {
                TcpClient socket = server.AcceptTcpClient();

                // håndtere samtidigt
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

                string cmdStr = sr.ReadLine();
                string data = sr.ReadLine();

                switch (cmdStr)
                {
                    case "HentAlle":
                        string json = JsonConvert.SerializeObject(_cykler);
                        sw.WriteLine(json);
                        break;

                    case "Hent":
                        int id = Int32.Parse(data);
                        Cykel cykel = _cykler.Find(c => c.Id == id);
                        string enCykelJson = JsonConvert.SerializeObject(cykel);
                        sw.WriteLine(enCykelJson);
                        break;

                    case "Gem":
                        Cykel nyCykel = JsonConvert.DeserializeObject<Cykel>(data);
                        _cykler.Add(nyCykel);
                        break;

                    default:
                        sw.WriteLine("Ikke en tilladt kommando");
                        break;
                }
            }
            socket?.Close(); // ? sikkerheds foranstaltning der ikke tillader null
        }
    }
}