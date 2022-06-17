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

namespace TopluMailGondermeApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        TopluMailGondermeAppEntitiesDbConnection db = new TopluMailGondermeAppEntitiesDbConnection();
        void Temizle()
        {
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = null;
            dataGridView1.DataSource = db.PersonelBilgileri.ToList();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Temizle();       
        }
        private void button1_Click(object sender, EventArgs e)
        {
            PersonelBilgileri p = new PersonelBilgileri();
            p.Ad = textBox1.Text;
            p.Soyad = textBox2.Text;
            p.Telefon = textBox3.Text;
            p.Mail = textBox4.Text;
            db.PersonelBilgileri.Add(p);
            db.SaveChanges();
            Temizle();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            PersonelBilgileri p = db.PersonelBilgileri.FirstOrDefault(x => x.Id == id);
            p.Ad = textBox1.Text;
            p.Soyad = textBox2.Text;
            p.Telefon = textBox3.Text;
            p.Mail = textBox4.Text;
            db.SaveChanges();
            Temizle();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            PersonelBilgileri p = db.PersonelBilgileri.FirstOrDefault(x => x.Id == id);
            DialogResult onay = new DialogResult();
            onay = MessageBox.Show($@"{dataGridView1.CurrentRow.Cells[1].Value.ToString()} {dataGridView1.CurrentRow.Cells[2].Value.ToString()} Personeli kalıcı olarak silinsin mi? ","Kalıcı Olarak Silinecek",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if (onay == DialogResult.Yes)
            {
                db.PersonelBilgileri.Remove(p);
                db.SaveChanges();
            }
            else
            {

            }
            Temizle();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            TopluMail tm = new TopluMail();
            tm.ShowDialog();
            this.Show();
        }
    }
}
