using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Collections;

namespace otomasyonn
{
    public partial class Form1 : Form
    {
        VeriTabaniFonksiyonlari vertitabani=new VeriTabaniFonksiyonlari();
        public Form1()
        {
            InitializeComponent();
        }
      
           
        private void button1_Click(object sender, EventArgs e)
        {
            ArrayList arrayList = new ArrayList();
            
            vertitabani.command=new OleDbCommand();
            vertitabani.command.CommandText=vertitabani.komut = "SELECT * FROM kullanicilar where isimcik=@ad and sifrecik=@sifre ";
       
            vertitabani.command.Parameters.AddWithValue("@ad", textBox1.Text);
            vertitabani.command.Parameters.AddWithValue("@sifre", textBox2.Text);
            arrayList =  vertitabani.veri_cek();
            if (arrayList.Count>0)
            {
                Form2 open = new Form2();
                open.ShowDialog();
            }


        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
         
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
