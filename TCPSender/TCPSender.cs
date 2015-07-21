using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;

namespace TCPSender
{
    class TCPSender : IDisposable
    {
        string server;
        int port;
        TcpClient client;
        NetworkStream stream;

        public void Dispose()
        {
            Console.WriteLine("TCPSender:disposing");
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if(disposing)
            {
                Console.WriteLine("TCPSender:managed resource disposing");

                if (this.client != null)
                {
                    this.client.Close();
                }

                if (this.stream != null)
                {
                    this.stream.Dispose();
                }
            }
        }

        ~TCPSender()
        {
            Console.WriteLine("TCPSender:destructor");
            Dispose(false);
        }

        public TCPSender(string server, int port)
        {
            this.server = server;
            this.port = port;
            this.client = null;
            this.stream = null;
        }

        public void Connect()
        {
            try
            {
                client = new TcpClient(server, port);
                stream = client.GetStream();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void Write(byte[] sendData)
        {
            if(this.stream != null && this.stream.CanWrite)
            {
                this.stream.Write(sendData, 0, sendData.Length);
            }
            else
            {
                // TODO:適当な例外にすべき。
                throw new Exception();
            }
        }
    }
}
