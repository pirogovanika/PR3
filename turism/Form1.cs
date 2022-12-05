using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace turism
{
    public partial class Form1 : Form
    {
        public int ID_char = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            staff Win = new staff();
            Win.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            clients Win = new clients();
            Win.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tour Win = new tour();
            Win.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            deal Win = new deal();
            Win.Show();
        }
    }
}
