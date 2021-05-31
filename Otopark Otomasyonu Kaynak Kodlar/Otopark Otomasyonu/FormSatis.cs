using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Otopark_Otomasyonu
{
    public partial class FormParkUcreti : Form
    {
        public FormParkUcreti()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-C50FCU3;Initial Catalog=arac_otopark;Integrated Security=True");
        DataSet daset = new DataSet();

        private void FormSatis_Load(object sender, EventArgs e)
        {
            ParkUcretListesi();
            Hesapla();
        }

        private void Hesapla()
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("select sum(tutar) from parkucreti", baglan);
            label1.Text = "Toplam Kazanç = " + komut.ExecuteScalar() + " TL ";
            baglan.Close();
        }

        private void ParkUcretListesi()
        {
            baglan.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select *from parkucreti ", baglan);
            adtr.Fill(daset, "parkucreti");
            dataGridView1.DataSource = daset.Tables["parkucreti"];
            baglan.Close();
        }
    }
}
