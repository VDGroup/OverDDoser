using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener listener = new TcpListener(45456); //Naslouchani pro nove klienty
            listener.Start(); //Spusteni naslouchani
            TcpClient client = listener.AcceptTcpClient(); //prijmuti klienta
            NetworkStream stream = client.GetStream();
            StreamReader sr = new StreamReader(stream);
            Console.WriteLine(sr.ReadLine()); //pockame si co nam poslou XD
            Console.WriteLine(sr.ReadLine()); 
            Console.ReadKey();
        }
    }
}
