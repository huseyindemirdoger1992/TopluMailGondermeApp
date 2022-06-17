using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TopluMailGondermeApp.DB;
using TopluMailGondermeApp.Models;

namespace TopluMailGondermeApp
{
    public partial class TopluMail : Form
    {
        public TopluMail()
        {
            InitializeComponent();
        }
        TopluMailGondermeAppEntitiesDbConnection db = new TopluMailGondermeAppEntitiesDbConnection();

        private void TopluMail_Load(object sender, EventArgs e)
        {
            label4.Text = $@"Toplam mail gönderilecek personel sayınız {db.PersonelBilgileri.Count().ToString()} kişidir.";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Gönderi İçin Ek Dosya Seçebilirsiniz.";
            ofd.ShowDialog();
            txtEk.Text = ofd.FileName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MailGondermeNesnesi mgn = new MailGondermeNesnesi();
            foreach (PersonelBilgileri p in db.PersonelBilgileri.ToList())
            {
                mgn.Microsoft(txtGAdSoayad.Text, txtGondericiMail.Text, txtGPass.Text, p.Mail , txtBaslik.Text, $@"Sayın {p.Ad} {p.Soyad} " + txtDetay.Text, txtEk.Text);

            }
            MessageBox.Show($@"Toplam {db.PersonelBilgileri.Count().ToString()} personele toplu mail gönderilmiştir.","Durum Bilgisi",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}
