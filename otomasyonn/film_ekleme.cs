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
using System.Security.Cryptography.X509Certificates;
using System.IO;

namespace otomasyonn
{
    public partial class film_ekleme : Form
    {
        VeriTabaniFonksiyonlari veritabani = new VeriTabaniFonksiyonlari();
        public film_ekleme()
        {
            InitializeComponent();
        }
        public string imagelocation = "";
       public ArrayList filmler=new ArrayList();
        
        private void button1_Click(object sender, EventArgs e)
        {
        byte[] image = File.ReadAllBytes(imagelocation);
           TimeSpan dateTime = new TimeSpan((int)comboBox1.SelectedItem, (int)comboBox1.SelectedItem, (int)comboBox1.SelectedItem);
        
            veritabani.command = new OleDbCommand();
            veritabani.command.CommandText = veritabani.komut = "insert into filmler (film,suresi,turu,yonetmen,afis) values (@filmm,@suresii,@turuu,@yonetmenn,@afiss)";
            veritabani.command.Parameters.AddWithValue("@filmm", textBox1.Text);
            veritabani.command.Parameters.AddWithValue("@suresii",dateTime);
            veritabani.command.Parameters.AddWithValue("@turuu", textBox3.Text);
            veritabani.command.Parameters.AddWithValue("@yonetmenn", textBox4.Text);
            veritabani.command.Parameters.AddWithValue("@afiss",image);
            veritabani.veri_gonder();
            guncel_Veri();
            textBox1.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox1.SelectedItem = null;
            comboBox2.SelectedItem=null;
            comboBox3.SelectedItem=null;
            pictureBox1.Image = null;

        }





        public void veri_guncelle() 
        {
            veritabani.command = new OleDbCommand();
             veritabani.command.CommandText=veritabani.komut = "select * from filmler ";
            ArrayList arrayList = veritabani.veri_cek();

           

        }

        private void film_ekleme_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 24; i++)
            {
                comboBox1.Items.Add(i);
            }
            for (int i = 0; i < 60; i++)
            {
                comboBox2.Items.Add(i);
                comboBox3.Items.Add(i);
            }


            guncel_Veri();



        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files(.*jpg)|*.jpg| PNG files(.*png)|*.png| All Files(*.*)|*.*";
                if (dialog.ShowDialog()==System.Windows.Forms.DialogResult.OK)
                {
                    imagelocation= dialog.FileName;
                   pictureBox1.ImageLocation = imagelocation;
                }
            }
            catch (Exception)
            {

                MessageBox.Show("error");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            veritabani.command = new OleDbCommand();
            veritabani.command.CommandText = veritabani.komut = "select * from filmler where film=@filmm";
            veritabani.command.Parameters.AddWithValue("@filmm", "fdsfsda");
            veritabani.connection = new OleDbConnection(veritabani.dataBaseAdress);
            veritabani.connection.Open();
            veritabani.command.Connection = veritabani.connection;

            veritabani.reader = veritabani.command.ExecuteReader();

            while (veritabani.reader.Read())
            {
                byte[] imageBytes = (byte[])veritabani.reader["afis"];
                MemoryStream ms = new MemoryStream(imageBytes);
                Image image = Image.FromStream(ms);
            
            }
            veritabani.connection.Close();
       

        }

        private void button4_Click(object sender, EventArgs e)
        {
          
            veritabani.command=new OleDbCommand();
            veritabani.command.CommandText=  veritabani.komut = "delete  from filmler where film=@filimcik";
            veritabani.command.Parameters.AddWithValue("@filimcik", listBox1.SelectedItem.ToString());
            veritabani.veri_sil();
            guncel_Veri();
        }
        public void guncel_Veri() 
        {
            listBox1.Items.Clear();
            veritabani.command = new OleDbCommand();
            veritabani.command.CommandText = veritabani.komut = "select film from filmler";
            filmler = veritabani.veri_cek();
            for (int i = 0; i < filmler.Count; i++)
            {
                listBox1.Items.Add(filmler[i]);
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
