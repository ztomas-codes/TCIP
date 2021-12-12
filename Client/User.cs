using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class User
    {

        public string Name;
        public TcpClient _client;
        public NetworkStream _stream;


        public User(string name)
        {
            _client = new TcpClient("127.0.0.1", 9999);
            _stream = _client.GetStream();
            this.Name = name;
            Send("Connected");
        }


        public void Send(string message)
        {
            string data = string.Empty;
            data = $"[{Name}]: {message}";
            WriteMessage(data);
        }

        private void WriteMessage(string message)
        {

            byte[] msg = Encoding.ASCII.GetBytes(message);
            _stream.Write(msg, 0, msg.Length);
        }
    }
}
