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

namespace Personel_Kayit
{
    public partial class FrmGiris : Form
    {
        public FrmGiris()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source = MUSOGBA; Initial Catalog = Personel_Veri_Tabani; Integrated Security = True");
        private void BtnGirisYap_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komut1 = new SqlCommand("Select * from Tbl_Yonetici where kullaniciadi =@k1 and sifre=@k2", baglanti);
            komut1.Parameters.AddWithValue("@k1",TxtKullaniciAdi.Text);
            komut1.Parameters.AddWithValue("@k2", TxtSifre.Text);
            SqlDataReader dr = komut1.ExecuteReader();
            if (dr.Read())
            {
                FrmAnaForm frm = new FrmAnaForm();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("GİRDİĞİNİZ KULLANICI ADI VEYA ŞİFRE YANLIŞTIR.","Bilgi",MessageBoxButtons.OKCancel,MessageBoxIcon.Information);
            }
           
        }
    }
}
