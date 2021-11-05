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
    public partial class admin : Form
    {
        public admin()
        {
            InitializeComponent();
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
            panel3.Controls.Add(childForm);
            panel3.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.BackColor = ColorTranslator.FromHtml("#b9d1ea");
            button2.BackColor = ColorTranslator.FromHtml("#99b4d1");
            //button3.BackColor = ColorTranslator.FromHtml("#99b4d1");
         //   button4.BackColor = ColorTranslator.FromHtml("#99b4d1");
            pictureBox1.Visible = false;
            openForm(new adm_stud());

        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.BackColor = ColorTranslator.FromHtml("#b9d1ea");
            button1.BackColor = ColorTranslator.FromHtml("#99b4d1");
          //  button3.BackColor = ColorTranslator.FromHtml("#99b4d1");
           // button4.BackColor = ColorTranslator.FromHtml("#99b4d1");
            pictureBox1.Visible = false;
            openForm(new adm_mark());
        }

        /*private void button3_Click(object sender, EventArgs e)
        {
            button3.BackColor = ColorTranslator.FromHtml("#b9d1ea");
            button2.BackColor = ColorTranslator.FromHtml("#99b4d1");
            button1.BackColor = ColorTranslator.FromHtml("#99b4d1");
            button4.BackColor = ColorTranslator.FromHtml("#99b4d1");
            pictureBox1.Visible = false;
            openForm(new adm_grp());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.BackColor = ColorTranslator.FromHtml("#b9d1ea");
            button2.BackColor = ColorTranslator.FromHtml("#99b4d1");
            button3.BackColor = ColorTranslator.FromHtml("#99b4d1");
            button1.BackColor = ColorTranslator.FromHtml("#99b4d1");
            pictureBox1.Visible = false;
            openForm(new adm_author());
        }*/
    }
}
