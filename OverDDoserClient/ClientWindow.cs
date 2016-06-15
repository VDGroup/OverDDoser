using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OverDDoserClient
{
    public partial class ClientWindow : Form
    {
        private Attacker attacker;
        public ClientWindow()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //try
            //{
                attacker = new Attacker(textBox1.Text, Convert.ToInt16(textBox2.Text), Convert.ToInt16(textBox4.Text), Convert.ToInt16(textBox5.Text), Convert.ToInt16(textBox3.Text), checkBox1.Checked);
                attacker.StartFlooding();
            //}
            //catch { MessageBox.Show("Fuck!"); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            attacker.StopFlooding();
        }
    }
}
