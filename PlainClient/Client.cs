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
            AutoSale dealer = new AutoSale("Jørgen", "Bolavej 32");
            dealer.Cars.Add(myCar);
            dealer.Cars.Add(new Car("Ford", "Blå", "AF3895"));

            using (TcpClient socket = new TcpClient("localhost", 10001))
            using (StreamWriter sw = new StreamWriter(socket.GetStream()))
            using (StreamReader sr = new StreamReader(socket.GetStream()))
            {
                sw.WriteLine(dealer);
                sw.Flush();
            }
        }
    }
}