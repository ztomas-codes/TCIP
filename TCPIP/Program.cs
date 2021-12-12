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
            // we set our IP address as server's address, and we also set the port: 9999

            server.Start();  // this will start the server
            while (true)
            {
                Console.WriteLine("Connected");
                TcpClient _client = server.AcceptTcpClient();
                using (NetworkStream stream = _client.GetStream())
                {
                    byte[] msg = new byte[256];
                    int bytes = stream.Read(msg, 0, msg.Length);
                    Console.WriteLine(Encoding.ASCII.GetString(msg));
                }
            }
        }
    }
}