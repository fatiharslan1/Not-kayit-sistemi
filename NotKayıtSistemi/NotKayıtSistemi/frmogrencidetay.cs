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

namespace NotKayıtSistemi
{
    public partial class frmogrencidetay : Form
    {
        public frmogrencidetay()
        {
            InitializeComponent();
        }

        public string numara;
        //Data Source=DESKTOP-0U62NCI;Initial Catalog=DbNotKayıt;Integrated Security=True

        SqlConnection baglantı = new SqlConnection(@"Data Source=DESKTOP-0U62NCI;Initial Catalog=DbNotKayıt;Integrated Security=True");
        private void frmogrencidetay_Load(object sender, EventArgs e)
        {
            lblnumara.Text = numara;

            baglantı.Open();
            SqlCommand komut = new SqlCommand("select * from TBLDERS where OGRNUMARA=@p1", baglantı);
            komut.Parameters.AddWithValue("@p1", numara);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                lbladsoyad.Text = dr[2].ToString() + " " + dr[3].ToString();
                lblsınav1.Text = dr[4].ToString();
                lblsınav2.Text = dr[5].ToString();
                lblsınav3.Text = dr[6].ToString();
                lblortalama.Text = dr[7].ToString();
                lbldurum.Text = dr[8].ToString();
            }
            baglantı.Close();
            if (lbldurum.Text == "True")
            {
                lbldurum.Text = "Geçti";
            }
            if (lbldurum.Text == "False")
            {
                lbldurum.Text = "Kaldı";
            }
        }
    }
}
