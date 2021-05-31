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
    public partial class AnaSayfa : Form
    {
        public AnaSayfa()
        {
            InitializeComponent();
        }

        SqlConnection baglan = new SqlConnection(BaglanClass.sqlconnection); 

        private void AnaSayfa_Load(object sender, EventArgs e)
        {

        }      

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            FormAraçOtoparkKaydı kayit = new FormAraçOtoparkKaydı();
            kayit.ShowDialog();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            FormAraçOtoparkYerleri yer = new FormAraçOtoparkYerleri();
            yer.ShowDialog();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            FormAraçOtoparkÇıkışSayfası cikis = new FormAraçOtoparkÇıkışSayfası();
            cikis.ShowDialog();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            FormParkUcreti parkucreti = new FormParkUcreti();
            parkucreti.ShowDialog();
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
    }

