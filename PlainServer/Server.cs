using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using ModelLib;

namespace PlainServer
{
    public class Server
    {
        public void Start()
        {
            TcpListener server = new TcpListener(IPAddress.Loopback, 10001);
            server.Start();

            while (true)
            {
                TcpClient socket = server.AcceptTcpClient();
                Task.Run(() =>
                {
                    TcpClient tmpSocket = socket;
                    DoClient(tmpSocket);
                });
            }
        }

        public void DoClient(TcpClient socket)
        {
            using (StreamWriter sw = new StreamWriter(socket.GetStream()))
            using (StreamReader sr = new StreamReader(socket.GetStream()))
            {
                string line = sr.ReadLine();
                string[] strArray = line.Split(',');

                AutoSale dealer = new AutoSale(strArray[0], strArray[1]);
                for (int i = 2; i < strArray.Length; i += 3)
                {
                    dealer.Cars.Add(new Car(strArray[i], strArray[i+1], strArray[i+2]));
                }
                Console.WriteLine(dealer);
            }
        }
    }
}