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
    public partial class FrmDoktorBilgiDuzenle : Form
    {
        public FrmDoktorBilgiDuzenle()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl = new SqlBaglantisi();
        public string tc;
        private void FrmDoktorBilgiDuzenle_Load(object sender, EventArgs e)
        {
            MskTC.Text = tc;

            SqlCommand komut2 = new SqlCommand("Select BransAd from Tbl_Branslar",bgl.baglanti());
            SqlDataReader dt2 = komut2.ExecuteReader();
            while(dt2.Read())
            {
                CmbBrans.Items.Add(dt2[0]);
            }

            SqlCommand komut = new SqlCommand("Select * From Tbl_Doktorlar where DoktorTC=@p1",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", MskTC.Text);
            SqlDataReader dt = komut.ExecuteReader();
            while (dt.Read())
            {
                TxtAd.Text = dt[1].ToString();
                TxtSoyad.Text = dt[2].ToString();
                CmbBrans.Text = dt[3].ToString();
                TxtSifre.Text = dt[5].ToString();
            }
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            //Bilgi Güncelle
            SqlCommand komut5 = new SqlCommand("update Tbl_Doktorlar set DoktorAd=@p1,DoktorSoyad=@p2,DoktorBrans=@p3,DoktorSifre=@p4 where DoktorTC=@p5", bgl.baglanti());
            komut5.Parameters.AddWithValue("@p1", TxtAd.Text);
            komut5.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            komut5.Parameters.AddWithValue("@p3", CmbBrans.Text);
            komut5.Parameters.AddWithValue("@p4", TxtSifre.Text);
            komut5.Parameters.AddWithValue("@p5", MskTC.Text);
            komut5.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Bilgileriniz Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
