using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace DiplomApp
{
    public partial class ControlTab : UserControl
    {
        public Panel panel;public Panel panel2; public string lt,grp; public int ind = 1000; public int cnt;public int kurs, diplom;
        public ControlTab()
        {
            InitializeComponent();
        }
                   
        public void label1_Click(object sender, EventArgs e)
        {

          
            ind = this.TabIndex;
            //lind = ind;
            panel.Controls.Clear();
            MySqlConnection MC = Form1.MC;

            using (MC)
            {
                if(MC.State == ConnectionState.Closed)
                MC.Open();
                 //MessageBox.Show(cnt.ToString());
                MySqlCommand stud_id = new MySqlCommand("select id_dis from dis_groups where id_grp=@grp order by id_dis desc limit 1 offset @j", MC);
                MySqlCommand stud_name = new MySqlCommand("select name from disciplines where id_dis=@id", MC);
                MySqlCommand comc1 = new MySqlCommand("select count(id_dis) from dis_groups where id_grp = @gr_id", Form1.MC);
                MySqlCommand come = new MySqlCommand("select ekzamen from dis_groups where id_grp = @gr_id and id_dis=@id", Form1.MC);
                MySqlCommand comz = new MySqlCommand("select zalik from dis_groups where id_grp = @gr_id and id_dis=@id", Form1.MC);
                comc1.Parameters.AddWithValue("gr_id", grp);
                int count = int.Parse(comc1.ExecuteScalar().ToString());
                if (count == 0)
                {
                    ControlTab2 gslist = new ControlTab2();
                    gslist.panel = this.panel2;
                    gslist.label4.Visible = true; //MessageBox.Show("123");
                    gslist.label1.Visible = false;  gslist.label3.Visible = false; gslist.lt = this.lt;
                    gslist.Dock = DockStyle.Fill;
                    gslist.label4.Text = "Нет записей\nдля выбранной группы: " + lt;
                    esize(gslist);
                    panel.Controls.Add(gslist);
                }
                for (int i = 0; i < count; i++)
                {
                    ControlTab2 gslist = new ControlTab2();
                    esize(gslist);
                    int sr=0; string name="", id="";
                    gslist.Dock = DockStyle.Top;  gslist.label3.Text = lt;
                    gslist.panel = this.panel2; gslist.state = this.kurs;
                    //comc1.Parameters.AddWithValue("lt", lt);
                    //int count1 = int.Parse(comc1.ExecuteScalar().ToString());
                    ////for (int j = 0; j < count1; j++)
                    // {
                     name = ""; id = "";
                     stud_id.Parameters.AddWithValue("j", i); stud_id.Parameters.AddWithValue("grp", grp); //MessageBox.Show(count1.ToString());

                    id = stud_id.ExecuteScalar().ToString(); gslist.lt = id;gslist.grp = grp; gslist.lt = this.lt;
                    stud_name.Parameters.AddWithValue("id", id);
                        
                        name = stud_name.ExecuteScalar().ToString();// MessageBox.Show(name);
                    come.Parameters.AddWithValue("gr_id", grp);
                    come.Parameters.AddWithValue("id", id);
                    comz.Parameters.AddWithValue("gr_id", grp);
                    comz.Parameters.AddWithValue("id", id);
                    int ek = int.Parse(come.ExecuteScalar().ToString());
                    int z = int.Parse(comz.ExecuteScalar().ToString());
                    if(ek==1)
                    {
                        gslist.label2.Text = "Екзамен";
                        gslist.label2.Visible = true;
                    }
                    if (z == 1)
                    {
                        gslist.label2.Text = "Залік";
                        gslist.label2.Visible = true;
                    }
                    if(ek!=1 && z!=1)
                    {
                        gslist.label2.Text = "(!)";
                        gslist.label2.Visible = true;
                    }

                    stud_id.Parameters.Clear(); stud_name.Parameters.Clear(); comc1.Parameters.Clear(); come.Parameters.Clear(); comz.Parameters.Clear();

                    //}

                    gslist.label1.Text = name;
                    gslist.label3.Text = lt;
                    panel.Controls.Add(gslist);
                    //panell.Controls.Add(glist);
                    // comc1.Parameters.Clear();
                }
            }
        }
        
        void esize(ControlTab2 gslist)
        {
           /* gslist.label1.Location = new Point(gslist.Width / 20, gslist.label1.Location.Y);
            gslist.label3.Location = new Point(gslist.Width / (gslist.Width / 2), gslist.Height / 14);
            gslist.label2.Location = new Point(gslist.Width / 2 + gslist.Width / 3, gslist.label2.Location.Y);
            gslist.label4.Location = new Point(gslist.Width / 34, gslist.label4.Location.Y);
            gslist.progres.Location = new Point(gslist.Width / 2 - gslist.Width / 14, gslist.progres.Location.Y);
            gslist.progres.Width = Width / 3;
            gslist.checkBox1.Location = new Point(Width / 3, gslist.checkBox1.Location.Y);*/
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
            panel2.Controls.Add(childForm);
            panel2.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void ControlTab_SizeChanged(object sender, EventArgs e)
        {
            //label1.Location = new Point(Width / 20, label1.Location.Y);
            //label2.Location = new Point(Width / 2 + Width / 3, label2.Location.Y);
            //label3.Location = new Point(Width / 34, label3.Location.Y);
           // progres.Location = new Point(Width / 2 - Width / 14, progres.Location.Y);
            //progres.Width = Width / 3;
           
        }

    }
}
