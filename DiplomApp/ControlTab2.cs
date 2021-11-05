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
    public partial class ControlTab2 : UserControl
    {
        public string lt; public Panel panel; public string grp;
        public ControlTab2()
        {
            InitializeComponent();
        }


        public int state; MySqlConnection MC = Form1.MC;
        private void label1_Click(object sender, EventArgs e)
        {
            
                
            /////////// SPISOK PUNKTOV///////////////
            panel.Controls.Clear();
            using (MC)
            {   
                if(MC.State == ConnectionState.Closed)
                MC.Open();
               
                ControlTab3 tab = new ControlTab3();
                //tab.panel = this.panel;
                tab.name = this.label1.Text;
                tab.grp = this.grp; tab.grn = this.lt;
                tab.label1.Visible = false;
                tab.Dock = DockStyle.Fill;
                esize(tab);
                panel.Controls.Add(tab);

            }
        }


        private void ControlTab2_SizeChanged(object sender, EventArgs e)
        {   
            
           /* label1.Location = new Point(Width / 20, label1.Location.Y);
            label3.Location = new Point(Width / (Width/2), Height/14);
            label2.Location = new Point(Width / 2 + Width / 3, label2.Location.Y);
            label4.Location = new Point(Width / 34, label4.Location.Y);
            progres.Location = new Point(Width / 2 - Width / 14, progres.Location.Y);
            progres.Width = Width / 3;
            checkBox1.Location = new Point(Width / 3 , checkBox1.Location.Y);*/
        }
        void esize(ControlTab3 gslist)
        {
           /* gslist.label1.Location = new Point(gslist.Width / 20, gslist.label1.Location.Y);
            gslist.label3.Location = new Point(gslist.Width / (gslist.Width / 2), gslist.Height / 14);
            gslist.label2.Location = new Point(gslist.Width / 2 + gslist.Width / 3, gslist.label2.Location.Y);
            gslist.progres.Location = new Point(gslist.Width / 2 - gslist.Width / 14, gslist.progres.Location.Y);
            gslist.progres.Width = Width / 3;*/
        }

        private void ControlTab2_Load(object sender, EventArgs e)
        {
           
        }
    }
}
