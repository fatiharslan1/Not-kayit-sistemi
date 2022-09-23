using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotKayıtSistemi
{
    public partial class frmGiris : Form
    {
        public frmGiris()
        {
            InitializeComponent();
        }

        private void btngiris_Click(object sender, EventArgs e)
        {
            frmogrencidetay fr = new frmogrencidetay();
            fr.numara = maskedTextBox1.Text;
            fr.Show();
           
        }

        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            if(maskedTextBox1.Text == "0000")
            {
                frmOgretmenDetay fr = new frmOgretmenDetay();
                fr.Show();
            }
        }
    }
}
