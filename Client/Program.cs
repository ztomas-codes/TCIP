using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Client;

public class Program
{

    public static User user;
    public static void Main()
    {
        Console.WriteLine("Napiš jmeno:");
        string username = Console.ReadLine();
        user = new User(username);
        string input = string.Empty;
        Thread t = new Thread(Listener);
        t.Start();
        while (input != "konec")
        {
            input = Console.ReadLine();
            user.Send(input);
        }
    }

    public static void Listener()
    {
        while (true)
        {
            byte[] bytes = new byte[100];
            user._client.GetStream().Read(bytes, 0, bytes.Length);
            Console.WriteLine(Encoding.ASCII.GetString(bytes));
        }
    }
}
