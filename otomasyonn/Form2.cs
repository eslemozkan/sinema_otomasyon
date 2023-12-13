using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace otomasyonn
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            kullanici_ekle open=new kullanici_ekle();
            open.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            film_ekleme open=new film_ekleme();
            open.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
