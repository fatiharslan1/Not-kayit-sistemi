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
    public partial class frmOgretmenDetay : Form
    {
        public frmOgretmenDetay()
        {
            InitializeComponent();
        }

        private void frmOgretmenDetay_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbNotKayıtDataSet.TBLDERS' table. You can move, or remove it, as needed.
            this.tBLDERSTableAdapter.Fill(this.dbNotKayıtDataSet.TBLDERS);

            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select count(*) from TBLDERS where DURUM='TRUE'", baglanti);
            SqlDataReader dr = komut2.ExecuteReader();
            while (dr.Read())
            {
                lblgecenogr.Text = dr[0].ToString();
            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("select count(*) from TBLDERS where DURUM='FALSE'", baglanti);
            SqlDataReader dr2 = komut3.ExecuteReader();
            while (dr2.Read())
            {
                lblkalanogr.Text = dr2[0].ToString();
            }
            baglanti.Close();


        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-0U62NCI;Initial Catalog=DbNotKayıt;Integrated Security=True");
        private void btnogrenciekle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into TBLDERS (OGRNUMARA,OGRAD,OGRSOYAD) values (@p1,@p2,@p3)",baglanti);
            komut.Parameters.AddWithValue("@p1", msknumara.Text);
            komut.Parameters.AddWithValue("@p2", txtad.Text);
            komut.Parameters.AddWithValue("@p3", txtsoyad.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Öğrenci ekleme İşlemi Başarılı","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            this.tBLDERSTableAdapter.Fill(this.dbNotKayıtDataSet.TBLDERS);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            txtsinav1.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            txtsinav2.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            txtsinav3.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            msknumara.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            txtsoyad.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
        }
        string durum;
        private void btnkaydet_Click(object sender, EventArgs e)
        {
            double ort, s1, s2, s3;

            s1 = Convert.ToDouble(txtsinav1.Text);
            s2 = Convert.ToDouble(txtsinav2.Text);
            s3 = Convert.ToDouble(txtsinav3.Text);

            ort = (s1 + s2 + s3) / 3;
            lblortalama.Text = ort.ToString();

            if (ort >= 50)
            {
                durum = "True";
            }
            else
            {
                durum = "False";
            }

            baglanti.Open();
            SqlCommand komut = new SqlCommand("update TBLDERS set OGRS1=@p1,OGRS2=@p2,OGRS3=@p3,ORTALAMA=@p4,DURUM=@p5 where OGRNUMARA=@p6", baglanti);
            komut.Parameters.AddWithValue("@p1", txtsinav1.Text);
            komut.Parameters.AddWithValue("@p2", txtsinav2.Text);
            komut.Parameters.AddWithValue("@p3", txtsinav3.Text);
            komut.Parameters.AddWithValue("@p4", decimal.Parse(lblortalama.Text));
            komut.Parameters.AddWithValue("@p5", durum);
            komut.Parameters.AddWithValue("@p6", msknumara.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Öğrrenci Notları Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.tBLDERSTableAdapter.Fill(this.dbNotKayıtDataSet.TBLDERS);
        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            msknumara.Text = "";
            txtad.Text = "";
            txtsoyad.Text = "";
            txtsinav1.Text = "";
            txtsinav2.Text = "";
            txtsinav3.Text = "";
        }

      
    }
}
