using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using ModelLib;

namespace PlainClient
{
    public class Client
    {
        public void Start()
        {
            Car myCar = new Car("Tesla", "Red", "EL3400");
            

            using (TcpClient socket = new TcpClient("localhost", 10001))
            using (StreamWriter sw = new StreamWriter(socket.GetStream()))
            using (StreamReader sr = new StreamReader(socket.GetStream()))
            {
                sw.WriteLine(myCar);
                sw.Flush();
            }
        }
    }
}