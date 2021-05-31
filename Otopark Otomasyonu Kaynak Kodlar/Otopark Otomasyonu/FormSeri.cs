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
    public partial class FormSeri : Form
    {
        public FormSeri()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-C50FCU3;Initial Catalog=arac_otopark;Integrated Security=True");
        private void marka()
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("select marka from markabilgileri", baglan);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                comboBoxEdit1.Properties.Items.Add(read["marka"].ToString());
            }
            baglan.Close();
        }

        private void FormSeri_Load(object sender, EventArgs e)
        {
            marka();
        }

        

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("insert into seribilgileri(marka,seri) values('" + comboBoxEdit1.Text + "','" + textBoxEdit1.Text + "') ", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            MessageBox.Show("Markanın araç serisi eklendi");
            textBoxEdit1.Text ="";
            comboBoxEdit1.Text = "";
            comboBoxEdit1.Properties.Items.Clear();
            marka();
        }
    }
}
