using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiplomApp
{
    public partial class Menu : Form
    {
        public Menu(ref string lvl, ref string login)
        {
            InitializeComponent();
            
            
        }
        
        private void Menu_Load(object sender, EventArgs e)
        {
            button3.BackColor = Color.White;
            button1.BackColor = Color.White; button1.ForeColor = Color.Black;
            panel2.Width = this.Width / 2;
            panel3.Width = this.Width / 2;
        }

        private void Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Form1.MC != null && Form1.MC.State != ConnectionState.Closed)//Закрываем соединение с БД
            {
                Form1.MC.Close();
                Application.Exit();
            }
            Form1.MC.Close();
            Application.Exit();
        }

        group_view dp = new group_view();
        private void button1_Click(object sender, EventArgs e)
        {   
            button1.BackColor = ColorTranslator.FromHtml("#99b4d1");
            button1.ForeColor = Color.White;
            button3.BackColor = Color.White;
            button3.ForeColor = Color.Black; button3.BackColor = Color.White;
            if (dp.IsDisposed == false)
            {
                dp.Dispose();
            }
            if (dp.IsDisposed==true)
            {
                dp = new group_view();
                dp.state = 1;
            }
            
            openForm(dp);
        }

  


        private void button3_Click(object sender, EventArgs e)
        {
            button3.BackColor = ColorTranslator.FromHtml("#99b4d1");
            button3.ForeColor = Color.White;
            button1.BackColor = Color.White;
            button1.ForeColor = Color.Black; button1.BackColor = Color.White;
            openForm(new admin());
        }

        private Form activeForm = null;
        private void openForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel1.Controls.Add(childForm);
            panel1.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void Menu_SizeChanged(object sender, EventArgs e)
        {
            /* dp.grouppanel.Width = dp.Width /3 ;
             dp.studentpanel.Width = dp.Width / 3;
             dp.personalpanel.Width = dp.Width / 3;
             dp.label1.Location = new Point(dp.panel1.Width / 82, dp.label1.Location.Y);
             dp.label4.Location = new Point(dp.panel3.Width / 82, dp.label4.Location.Y);
             dp.label6.Location = new Point(dp.ppanel.Width / 82, dp.label6.Location.Y);
             dp.label2.Location = new Point(dp.panel1.Width / 3 + dp.panel1.Width / 17, dp.label2.Location.Y);
             dp.label3.Location = new Point(dp.panel3.Width / 3 + dp.panel3.Width / 17, dp.label3.Location.Y);
             dp.label5.Location = new Point(dp.ppanel.Width / 3 + dp.ppanel.Width / 17, dp.label5.Location.Y);
             dp.gpanel.Width = dp.grouppanel.Width;
             dp.panell.Width = dp.studentpanel.Width;
             dp.panel4.Width = dp.personalpanel.Width;

             kurs.grouppanel.Width = kurs.Width / 3;
             kurs.studentpanel.Width = kurs.Width / 3;
             kurs.personalpanel.Width = kurs.Width / 3;
             kurs.label1.Location = new Point(kurs.panel1.Width / 82, kurs.label1.Location.Y);
             kurs.label4.Location = new Point(kurs.panel3.Width / 82, kurs.label4.Location.Y);
             kurs.label6.Location = new Point(kurs.ppanel.Width / 82, kurs.label6.Location.Y);
             kurs.label2.Location = new Point(kurs.panel1.Width / 3 + kurs.panel1.Width / 17, kurs.label2.Location.Y);
             kurs.label3.Location = new Point(kurs.panel3.Width / 3 + kurs.panel3.Width / 17, kurs.label3.Location.Y);
             kurs.label5.Location = new Point(kurs.ppanel.Width / 3 + kurs.ppanel.Width / 17, kurs.label5.Location.Y);
             kurs.gpanel.Width = kurs.grouppanel.Width;
             kurs.panell.Width = kurs.studentpanel.Width;
             kurs.panel4.Width = kurs.personalpanel.Width;*/
            panel2.Width = this.Width / 2;
            panel3.Width = this.Width / 2;
        }
        
    }
}
