using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Otopark_Otomasyonu
{
    public partial class FormMarka : Form
    {
        public FormMarka()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-C50FCU3;Initial Catalog=arac_otopark;Integrated Security=True");


       

        private void FormMarka_Load(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("insert into markabilgileri(marka) values('" + textBoxEdit1.Text + "') ", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            MessageBox.Show("Marka Eklendi");
            textBoxEdit1.Text = "";

        }

        private void labelEdit1_Click(object sender, EventArgs e)
        {

        }
    }
}
