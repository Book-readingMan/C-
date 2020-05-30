using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace work_lesson9
{
    class Client
    {
        public void run()
        {
            using (TcpClient client = new TcpClient(@"localhost", 100000))
            {
                using (NetworkStream networkStream = client.GetStream())
                {
                    string message = null;
                    do
                    {
                        message = Console.ReadLine();
                        byte[] data = Encoding.UTF8.GetBytes(message);
                        networkStream.Write(data, 0, data.Length);
                    } while (message !="q");
                }
            }
        }
    }
}
