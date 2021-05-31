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
using DevExpress.XtraEditors;

namespace Otopark_Otomasyonu
{
    public partial class FormAraçOtoparkYerleri : Form
    {
        public FormAraçOtoparkYerleri()
        {
            InitializeComponent();
        }

        SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-C50FCU3;Initial Catalog=arac_otopark;Integrated Security=True"); 
        private void FormAraçOtoparkYerleri_Load(object sender, EventArgs e)
        {
            BosParkYerleri();
            DoluParkYerleri();
            baglan.Open();
            SqlCommand komut = new SqlCommand("select *from arac_otopark_kaydı", baglan);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                foreach (Control item in Controls)
                {
                    if (item is SimpleButton)
                    {
                        if (item.Text == read["parkyeri"].ToString())
                        {
                            item.Text = read["plaka"].ToString();

                        }

                    }
                }
            }
            baglan.Close();
        }

        private void DoluParkYerleri()
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("select *from aracdurumu", baglan);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                foreach (Control item in Controls)
                {
                    if (item is SimpleButton)
                    {
                        if (item.Text == read["parkyeri"].ToString() && read["durumu"].ToString() == "DOLU")
                        {
                            item.ForeColor = Color.Red;

                        }

                    }
                }
            }
            baglan.Close();
        }

        private void BosParkYerleri()
        {
            int sayac = 1;
            foreach (Control item in Controls)
            {
                if (item is SimpleButton)
                {
                    item.Text = "A-" + sayac;
                    item.Name = "A-" + sayac;
                    sayac++;
                }
            }
        }
    }
}
