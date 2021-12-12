using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    class Client
    {
        public static List<Client> clients = new List<Client>();

        public TcpClient TcpClient;
        public NetworkStream NetworkStream;
        Thread Thread;
        public Client(TcpClient client)
        {
            TcpClient = client;
            NetworkStream = client.GetStream();
            clients.Add(this);
            Thread = new Thread(ChatHandling);
            Thread.Start();

        }

        public void ChatHandling()
        {
            while (true)
            {
                byte[] bytes = new byte[100];
                NetworkStream.Read(bytes, 0, bytes.Length);
                Console.WriteLine(Encoding.ASCII.GetString(bytes));
                Program.Broadcast(Encoding.ASCII.GetString(bytes));
            }
        }
    }
}
