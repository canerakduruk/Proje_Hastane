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

namespace Proje_Hastane
{
    public partial class FrmBilgiDuzenle : Form
    {
        public FrmBilgiDuzenle()
        {
            InitializeComponent();
        }

        public string tcNo;
        SqlBaglantisi bgl = new SqlBaglantisi();
        private void FrmBilgiDuzenle_Load(object sender, EventArgs e)
        {
            MskTC.Text = tcNo;

            //Bilgi Çekme
            SqlCommand komut4 = new SqlCommand("Select HastaAd,HastaSoyad,HastaTelefon,HastaSifre,HastaCinsiyet From Tbl_Hastalar where HastaTC=" + tcNo, bgl.baglanti());
            SqlDataReader dr4 = komut4.ExecuteReader();
            while(dr4.Read())
            {
                TxtAd.Text = dr4[0].ToString();
                TxtSoyad.Text = dr4[1].ToString();
                MskTelefon.Text = dr4[2].ToString();
                TxtSifre.Text = dr4[3].ToString();
                CmbCinsiyet.Text = dr4[4].ToString();
            }
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            //Bilgi Güncelle
            SqlCommand komut5 = new SqlCommand("update Tbl_Hastalar set HastaAd=@p1,HastaSoyad=@p2,HastaTelefon=@p3,HastaSifre=@p4,HastaCinsiyet=@p5 where HastaTC=@p6", bgl.baglanti());
            komut5.Parameters.AddWithValue("@p1", TxtAd.Text);
            komut5.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            komut5.Parameters.AddWithValue("@p3", MskTelefon.Text);
            komut5.Parameters.AddWithValue("@p4", TxtSifre.Text);
            komut5.Parameters.AddWithValue("@p5", CmbCinsiyet.Text);
            komut5.Parameters.AddWithValue("@p6", MskTC.Text);
            komut5.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Bilgileriniz Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
