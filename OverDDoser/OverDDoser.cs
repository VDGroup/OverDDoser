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
        
        public OverDDoser(string[] Args)
        {
            Form1 f = new Form1();
            f.ShowDialog();
            NetworkStream s = f.stream;
            StreamReader sr = new StreamReader(s);
            string Address = sr.ReadLine();
            MessageBox.Show(Address);
        }
    }
}
