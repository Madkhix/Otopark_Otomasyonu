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
    public partial class FormAraçOtoparkÇıkışSayfası : Form
    {
        public FormAraçOtoparkÇıkışSayfası()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-C50FCU3;Initial Catalog=arac_otopark;Integrated Security=True");


        private void FormAraçOtoparkÇıkışSayfası_Load(object sender, EventArgs e)
        {
            DoluYerler();
            Plakalar();
            timer1.Enabled = true;
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {
            
        }

        private void Plakalar()
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("select *from arac_otopark_kaydı", baglan);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                comboPlakaEdit.Properties.Items.Add(read["plaka"].ToString());
            }
            baglan.Close();
        }

        private void DoluYerler()
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("select *from aracdurumu where durumu='DOLU'", baglan);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                comboParkYeriEdit.Properties.Items.Add(read["parkyeri"].ToString());
            }
            baglan.Close();
        }

   private void timer1_Tick(object sender, EventArgs e)
        {          
            lblCikisEdit.Text = DateTime.Now.ToString();
        }

        

       


        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("delete from arac_otopark_kaydı where plaka='" + textPlakaEdit.Text + "'", baglan);
            komut.ExecuteNonQuery();
            SqlCommand komut2 = new SqlCommand("update aracdurumu set durumu='BOŞ' where parkyeri='" + textParkYeriEdit2.Text + "'", baglan);
            komut2.ExecuteNonQuery();
            SqlCommand komut3 = new SqlCommand("insert into parkucreti(parkyeri,plaka,giriş_tarihi,çıkış_tarihi,süre,tutar) values(@parkyeri,@plaka,@giriş_tarihi,@çıkış_tarihi,@süre,@tutar) ", baglan);
            komut3.Parameters.AddWithValue("@parkyeri", textParkYeriEdit2.Text);
            komut3.Parameters.AddWithValue("@plaka", textPlakaEdit.Text);
            komut3.Parameters.AddWithValue("@giriş_tarihi", lblGirisEdit.Text);
            komut3.Parameters.AddWithValue("@çıkış_tarihi", lblCikisEdit.Text);
            komut3.Parameters.AddWithValue("@süre", double.Parse(lblParkEdit.Text));
            komut3.Parameters.AddWithValue("@tutar", double.Parse(lblTutarEdit.Text));
            komut3.ExecuteNonQuery();

            baglan.Close();
            MessageBox.Show("Araç çıkışı gerçekleşti.");
            foreach (Control item in groupControl2.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                    textParkYeriEdit1.Text = "";
                    comboParkYeriEdit.Text = "";
                    comboPlakaEdit.Text = "";
                }
            }
            comboPlakaEdit.Properties.Items.Clear();
            comboParkYeriEdit.Properties.Items.Clear();
            DoluYerler();
            Plakalar();
        }

        private void comboParkYeriEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("select *from arac_otopark_kaydı where parkyeri='" + comboParkYeriEdit.SelectedItem + "'", baglan);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                textParkYeriEdit2.Text = read["parkyeri"].ToString();
                textTcEdit.Text = read["tc"].ToString();
                textAdEdit.Text = read["ad"].ToString();
                textSoyadEdit.Text = read["soyad"].ToString();
                textMarkaEdit.Text = read["marka"].ToString();
                textSeriEdit.Text = read["seri"].ToString();
                textPlakaEdit.Text = read["plaka"].ToString();
                lblGirisEdit.Text = read["tarih"].ToString();
            }
            baglan.Close();
            DateTime giris, cikis;
            giris = DateTime.Parse(lblGirisEdit.Text);
            cikis = DateTime.Parse(lblCikisEdit.Text);
            TimeSpan zfark;
            zfark = cikis - giris;
            lblParkEdit.Text = zfark.TotalHours.ToString("0.00");
            lblTutarEdit.Text = (double.Parse(lblParkEdit.Text) * (0.75)).ToString("0.00");
        }

        private void comboPlakaEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("select *from arac_otopark_kaydı where plaka='" + comboPlakaEdit.SelectedItem + "'", baglan);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                textParkYeriEdit1.Text = read["parkyeri"].ToString();
            }
            baglan.Close();
        }
    }
}
