using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp50
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection CNT = new SqlConnection("Data Source=LAPTOP-TH19MO2H\\SQLEXPRESS;Initial Catalog=\"emlakkayıt\";Integrated Security=True");
        private void verilerigoster()
        {
            listView1.Items.Clear();  
            
            CNT.Open();
            SqlCommand komut = new SqlCommand("SELECT *FROM buildingusers", CNT);

            SqlDataReader oku = komut.ExecuteReader();
            // Aşağıdaki while döngüsünde tanımlanan sürün isimleri benim kendi veri tabanımda oluşturduğum veri tabanımdaki sütun isimleridir
            //  Kendi bilgisayarınızda bu projeyi çalıştırmanız için sütunları ayaparlamanız gerekmektedir. 
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text  = oku[ "id"].ToString();
                ekle.SubItems.Add(oku["name"].ToString());
                ekle.SubItems.Add(oku["surname"].ToString());
                ekle.SubItems.Add(oku["buildings"].ToString());
                ekle.SubItems.Add(oku["apartment"].ToString());
                listView1.Items.Add(ekle);
            }
            CNT.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
           verilerigoster();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            CNT.Open();
            SqlCommand komut = new SqlCommand("insert into buildingusers(id,name,surname,buildings,apartment) Values('"+textBox1.Text.ToString ()+"','"+textBox2.Text.ToString()+"','"+textBox3.Text.ToString()+"','"+textBox4.Text.ToString()+"','"+textBox5.Text.ToString()+"')",CNT);
            komut.ExecuteNonQuery();
            CNT.Close();
            verilerigoster();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        int numara = 0;
        private void button3_Click(object sender, EventArgs e)
        {

          
            CNT.Open();
            SqlCommand komut = new SqlCommand("Delete From buildingusers where id=("+numara+")", CNT);
            komut.ExecuteNonQuery();
            CNT.Close();
            verilerigoster();

        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            numara=int.Parse(listView1.SelectedItems[0].SubItems[0].Text);


            textBox1.Text= listView1.SelectedItems[0].SubItems[0].Text;
            textBox2.Text= listView1.SelectedItems[0].SubItems[1].Text;
            textBox3.Text= listView1.SelectedItems[0].SubItems[2].Text;
            textBox4.Text= listView1.SelectedItems[0].SubItems[3].Text;
            textBox5.Text=listView1.SelectedItems[0].SubItems[4].Text;


        }

        private void button4_Click(object sender, EventArgs e)
        {
           CNT.Open();
            
            
            
            SqlCommand komut = new SqlCommand("Update  buildingusers set id ='"+textBox1.Text.ToString()+"',name='"+textBox2.Text.ToString()+"' ,surname='"+textBox3.Text.ToString()+"',buildings ='"+textBox4.Text.ToString()+"',apartment='"+textBox5.Text.ToString()+"' where id =("+numara+")",CNT);

            komut.ExecuteNonQuery();
            CNT .Close();
            verilerigoster ();



        }
    }
}
