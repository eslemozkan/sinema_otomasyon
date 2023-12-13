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
    public partial class kullanici_ekle : Form
    {
        public kullanici_ekle()
        {
            InitializeComponent();
        }
        VeriTabaniFonksiyonlari veritabani=new VeriTabaniFonksiyonlari();
        private void button1_Click(object sender, EventArgs e)
        {
            veritabani.command = new OleDbCommand();
            veritabani.command.Parameters.Clear();
            veritabani.command.CommandText = veritabani.komut = "SELECT * FROM kullanicilar where isimcik=@ad ";
            veritabani.command.Parameters.AddWithValue("@ad",textBox1.Text);
           ArrayList list= veritabani.veri_cek();

            if (list.Count>0)
            {
                MessageBox.Show("Bu kullanıcı adı zaten alınmış");
            }
            else {     if (textBox3.Text==textBox2.Text)
            {
  veritabani.command = new OleDbCommand();
            veritabani.command.Parameters.Clear();
           veritabani.command.CommandText= veritabani.komut = "INSERT INTO kullanicilar (isimcik,sifrecik) VALUES (@ekemk,@kepek)";
            veritabani.command.Parameters.AddWithValue("@ekemk", textBox1.Text);
            veritabani.command.Parameters.AddWithValue("@kepek", textBox3.Text);
            veritabani.veri_gonder();
                    comboboxguncelle();
            }
            else
            {
                    MessageBox.Show("birinci şifre ile ikinci şifre aynı değil");
            }
            }
        
          

        }

        private void button2_Click(object sender, EventArgs e)
        {
            veritabani.command = new OleDbCommand();
            veritabani.command.Parameters.Clear();
            veritabani.command.CommandText = veritabani.komut = "delete from kullanicilar where isimcik=@ekem";
            veritabani.command.Parameters.AddWithValue("@ekem", comboBox1.SelectedItem.ToString());
            veritabani.veri_sil();
            comboboxguncelle();



        }

        private void kullanici_ekle_Load(object sender, EventArgs e)
        {
            comboboxguncelle();
        }

        public void comboboxguncelle()
        {
            comboBox1.Items.Clear();
            veritabani.command = new OleDbCommand();
            veritabani.command.Parameters.Clear();
            veritabani.command.CommandText = veritabani.komut = "SELECT isimcik FROM kullanicilar ";
            ArrayList list = veritabani.veri_cek();
            if (list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    comboBox1.Items.Add(list[i]);
                }

            }

        }
    }
}
