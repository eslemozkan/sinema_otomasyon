using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Collections;

namespace otomasyonn
{
    internal class VeriTabaniFonksiyonlari
    {
        #region
        public string dataBaseAdress = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\elife\\OneDrive\\Documents\\BiletSatisOtomasyonu.accdb";
        public string komut="";
        public OleDbConnection connection;
        public OleDbCommand command ;
        public OleDbDataReader reader;
        #endregion
        public ArrayList veri_cek()
        {
            ArrayList cikti=new ArrayList();
        connection = new OleDbConnection(dataBaseAdress);
        connection.Open();
        command.Connection=connection;
            
            reader = command.ExecuteReader();
           
            while (reader.Read())
                   {string kelime = "";
                if (reader!=null)
                {
                    
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        kelime += reader[i].ToString();
                    }
                }
                cikti.Add(kelime);
               
            }
            connection.Close();
            return cikti;

        }

        public void veri_gonder()
        {
            connection = new OleDbConnection(dataBaseAdress);
            connection.Open();
            command.Connection=connection;
            command.ExecuteNonQuery();
            connection.Close();
        
        }


        public void veri_sil() 
        {
            ArrayList cikti = new ArrayList();
            connection = new OleDbConnection(dataBaseAdress);
            connection.Open();
            command.Connection = connection;
            command.ExecuteNonQuery();
            connection.Close();

        }
    }
}
