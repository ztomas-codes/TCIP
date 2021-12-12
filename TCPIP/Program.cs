using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net;      //required
using System.Net.Sockets;    //required

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener server = new TcpListener(IPAddress.Any, 9999);
            server.Start();
            while (true)
            {
                TcpClient client = server.AcceptTcpClient();
                new Client(client);
            }

        }

        public static void Broadcast(string msg)
        {
            foreach(Client client in Client.clients)
            {
                byte[] bytes = Encoding.ASCII.GetBytes(msg);

                client.TcpClient.GetStream().Write(bytes, 0, bytes.Length);
            }
        }
    }
}