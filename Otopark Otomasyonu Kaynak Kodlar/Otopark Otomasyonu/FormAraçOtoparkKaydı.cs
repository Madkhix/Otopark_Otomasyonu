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
    public partial class FormAraçOtoparkKaydı : Form
    {
        public FormAraçOtoparkKaydı()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-C50FCU3;Initial Catalog=arac_otopark;Integrated Security=True");

        private void FormAraçOtoparkKaydı_Load(object sender, EventArgs e)
        {
            BosAraclar();
            Marka();
           
        }

        private void Marka()
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("select marka from markabilgileri", baglan);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                comboEditMarka.Properties.Items.Add(read["marka"].ToString());
            }
            baglan.Close();
        }

        private void BosAraclar()
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("select *from aracdurumu WHERE durumu='BOŞ'", baglan);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                comboEditParkYeri.Properties.Items.Add(read["parkyeri"].ToString());
            }
            baglan.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("insert into arac_otopark_kaydı(tc,ad,soyad,telefon,email,plaka,marka,seri,renk,parkyeri,tarih) values(@tc,@ad,@soyad,@telefon,@email,@plaka,@marka,@seri,@renk,@parkyeri,@tarih)", baglan);
            komut.Parameters.AddWithValue("@tc", txtEditTc.Text);
            komut.Parameters.AddWithValue("@ad", txtEditAd.Text);
            komut.Parameters.AddWithValue("@soyad", txtEditSoyad.Text);
            komut.Parameters.AddWithValue("@telefon", txtEditTelefon.Text);
            komut.Parameters.AddWithValue("@email", txtEditEmail.Text);
            komut.Parameters.AddWithValue("@plaka", txtEditPlaka.Text);
            komut.Parameters.AddWithValue("@marka", comboEditMarka.Text);
            komut.Parameters.AddWithValue("@seri", comboEditSeri.Text);
            komut.Parameters.AddWithValue("@renk", txtEditRenk.Text);
            komut.Parameters.AddWithValue("@parkyeri", comboEditParkYeri.Text);
            komut.Parameters.AddWithValue("@tarih", DateTime.Now.ToString());

            komut.ExecuteNonQuery();

            SqlCommand komut2 = new SqlCommand("update aracdurumu set durumu='DOLU' where parkyeri='" + comboEditParkYeri.SelectedItem + "'", baglan);
            komut2.ExecuteNonQuery();
            baglan.Close();
            MessageBox.Show("Araç kaydı oluşturuldu", "Kayıt");
            comboEditParkYeri.Properties.Items.Clear();
            BosAraclar();
            comboEditMarka.Properties.Items.Clear();
            Marka();
            comboEditSeri.Properties.Items.Clear();
            foreach (Control item in grupControlKisi.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
            foreach (Control item in grupControlArac.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
            foreach (Control item in grupControlArac.Controls)
            {
                if (item is ComboBox)
                {
                    item.Text = "";
                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButtonMarka_Click(object sender, EventArgs e)
        {
            FormMarka marka = new FormMarka();
            marka.ShowDialog();
        }

        private void simpleButtonSeri_Click(object sender, EventArgs e)
        {
            FormSeri seri = new FormSeri();
            seri.ShowDialog();
        }

        private void groupControl2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboEditMarka_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboEditSeri.Properties.Items.Clear();
            baglan.Open();
            SqlCommand komut = new SqlCommand("select marka,seri from seribilgileri where marka='" + comboEditMarka.SelectedItem + "'", baglan);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                comboEditSeri.Properties.Items.Add(read["seri"].ToString());
            }
            baglan.Close();

        }
    }
}
