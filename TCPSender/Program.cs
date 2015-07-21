using System;
using System.Collections.Generic;
using System.Text;

namespace TCPSender
{
    class Program
    {
        static void Main(string[] args)
        {
            using(TCPSender sender = new TCPSender("127.0.0.1", 15000))
            {
                string message = "hogehoge";
                byte[] data = Encoding.UTF8.GetBytes(message);
                sender.Connect();
                Console.WriteLine("Write data:{0}", message);
                sender.Write(data);
            }
        }
    }
}
