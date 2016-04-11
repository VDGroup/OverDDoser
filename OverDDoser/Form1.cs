using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace OverDDoser
{
    public partial class Form1 : Form
    {
        public NetworkStream stream;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string address = textBox1.Text;
                TcpClient client = new TcpClient();
                client.Connect(address, 45456);
                stream = client.GetStream();
                //TO bude ono :D
                StreamWriter sw = new StreamWriter(stream);
                sw.WriteLine(textBox2.Text);
                sw.WriteLine(textBox3.Text);
                sw.Flush(); //tohle odesle data
                this.Close();
            }
            catch { }
        }
    }
}
