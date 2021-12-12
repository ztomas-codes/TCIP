using System;
using System.Net.Sockets;
using Client;

public class Program
{
    public static void Main()
    {
        User user = new User("test");
        string input = string.Empty;
        while (input != "konec")
        {
            input = Console.ReadLine();
            user.Send(input);
        }
    }
}
