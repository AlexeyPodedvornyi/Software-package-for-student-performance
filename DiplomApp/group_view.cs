using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace DiplomApp
{
    public partial class group_view : Form
    {
       
        public group_view()
        {
            InitializeComponent();
        }
        public static string b;
        private void diplom_Load(object sender, EventArgs e)
        {
            vivod();
            
            //openForm(new Tab3());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            vivod();
            panell.Controls.Clear();
            panel4.Controls.Clear();
            label2.Text = "Для відображення таблиці успішності студентів оберіть номер группи та дисципліну";
        }
        public int state;
        public void vivod()
        {
            chart1.Series.Clear();gpanel.Controls.Clear();//chart1.Dispose();
            using (Form1.MC)
            {
                MySqlCommand com = new MySqlCommand("select name from g_roups order by name desc limit 1 offset @i", Form1.MC);
                MySqlCommand comstd = new MySqlCommand("select id_dis from dis_groups where id_grp = @gr_id order by id_dis limit 1 offset @j", Form1.MC);
                MySqlCommand coms = new MySqlCommand("select id_stud from students where id_grp = @grp limit 1 offset @j", Form1.MC);
                MySqlCommand comsc = new MySqlCommand("select count(*) from students where id_grp = @grp", Form1.MC);
                MySqlCommand comprogres = new MySqlCommand("select sum(PK1+MK1+PK2+MK2) from progress where id_stud = @std and id_dis=@dis", Form1.MC);
                MySqlCommand comprogres2 = new MySqlCommand("select dp from progress where id_stud = @std and id_dis=@dis", Form1.MC);
                MySqlCommand comprogres3 = new MySqlCommand("select kurs from progress where id_stud = @std and id_dis=@dis", Form1.MC);
                MySqlCommand comc = new MySqlCommand("select count(*) from g_roups", Form1.MC);
                // MySqlCommand comp = new MySqlCommand("select count(*) from cont_parts", Form1.MC);
                MySqlCommand comc2 = new MySqlCommand("select id_grp from g_roups where name = @name", Form1.MC);
                MySqlCommand comc1 = new MySqlCommand("select count(id_dis) from dis_groups where id_grp = @gr_id", Form1.MC);
              //  MySqlCommand comc2 = new MySqlCommand("select count(id_grp) from g_roups where id_b = @gr_id", Form1.MC);
                Form1.MC.OpenAsync();
                int count = int.Parse(comc.ExecuteScalar().ToString());
               
                if(count==0)
                {
                    ControlTab glist = new ControlTab();
                    esize(glist); glist.diplom = this.state;
                    glist.label3.Text = "Записи про групи відсутні!";
                    glist.label3.Visible = true;
                    glist.label1.Visible = false;

                    gpanel.Controls.Add(glist);
                }

                string gr_id, std, name, dis;
                string p1, p2;
                for (int i = 0; i < count; i++)
                {
                    name = ""; gr_id = ""; int sr_gr = 0;p1 = "";p2 = "";
                    ControlTab glist = new ControlTab();
                    esize(glist); glist.diplom = this.state;
                    glist.label1.Location =  new Point(glist.Width / 20, glist.label1.Location.Y);
                    glist.panel = this.panell; glist.panel2 = this.panel4;
                    glist.Dock = DockStyle.Top;
                    com.Parameters.AddWithValue("i", i);
                    name = com.ExecuteScalar().ToString();
                    comc2.Parameters.AddWithValue("name",name);
                    gr_id = comc2.ExecuteScalar().ToString();
                    comc1.Parameters.AddWithValue("gr_id", gr_id);
                    //std = comstd.ExecuteScalar().ToString(); 
                    int count1 = int.Parse(comc1.ExecuteScalar().ToString());
                    if (count1 == 0)
                        glist.cnt = count1;
                    //MessageBox.Show(count1.ToString());
                    int dp, kurs,d=0,k=0;
                    /*for (int j = 0; j < count1; j++)    //prohod po disciplinam
                    {
                        comstd.Parameters.AddWithValue("j", j); comstd.Parameters.AddWithValue("gr_id", gr_id);
                        dis = comstd.ExecuteScalar().ToString();
                        /*comz.Parameters.AddWithValue("gr_id", gr_id); comz.Parameters.AddWithValue("dis", dis);
                        int z = int.Parse(comz.ExecuteScalar().ToString());
                        if(z==1)
                                
                        
                       
                        comprogres.Parameters.Clear(); comprogres2.Parameters.Clear(); comprogres3.Parameters.Clear();
                        comstd.Parameters.Clear(); comz.Parameters.Clear();
                    }*/
                    comsc.Parameters.AddWithValue("grp", gr_id);
                   int count2 = int.Parse(comsc.ExecuteScalar().ToString());
                    //sr_gr = sr_gr / count1;
                    
                    for (int j = 0; j < count2; j++) ///prohod po studentam
                    {
                        d = 0; k = 0;std = "";
                        MySqlCommand comc4 = new MySqlCommand("select count(*) from students where id_grp = @gr_id", Form1.MC);
                        comc4.Parameters.AddWithValue("gr_id", gr_id);
                        int c4 = int.Parse(comc4.ExecuteScalar().ToString());
                        if (c4 != 0)
                        {
                            coms.Parameters.AddWithValue("j", j); coms.Parameters.AddWithValue("grp", gr_id);
                            std = coms.ExecuteScalar().ToString();
                            MySqlCommand comc3 = new MySqlCommand("select count(*) from progress where id_stud = @std", Form1.MC);
                            MySqlCommand comcd = new MySqlCommand("select id_dis from progress where id_stud = @std limit 1 offset @J", Form1.MC);
                            MySqlCommand comz = new MySqlCommand("select zalik from dis_groups where id_grp=@gr_id and id_dis=@dis", Form1.MC);
                            comc3.Parameters.AddWithValue("std", std);
                            int c3 = int.Parse(comc3.ExecuteScalar().ToString());
                           
                            for (int g=0;g<c3;g++)
                            {
                                dis = "";
                                comcd.Parameters.AddWithValue("J", g); comcd.Parameters.AddWithValue("std", std);
                                dis = comcd.ExecuteScalar().ToString();
                                comz.Parameters.AddWithValue("gr_id", gr_id); comz.Parameters.AddWithValue("dis", dis);
                                int z = int.Parse(comz.ExecuteScalar().ToString());
                                if (z != 1)
                                {
                                    comprogres = new MySqlCommand("select sum(PK1+MK1+PK2+MK2) from progress where id_stud = @std and id_dis=@dis", Form1.MC);
                                }
                                else
                                    comprogres = new MySqlCommand("select sum(PK1+PK2) from progress where id_stud = @std and id_dis=@dis", Form1.MC);
                                comprogres2.Parameters.AddWithValue("std", std);
                                comprogres2.Parameters.AddWithValue("dis", dis);
                                comprogres3.Parameters.AddWithValue("std", std);
                                comprogres3.Parameters.AddWithValue("dis", dis);
                                p1 = comprogres2.ExecuteScalar().ToString();
                                p2 = comprogres3.ExecuteScalar().ToString();
                                if (p1 == "-")
                                    dp = 0;
                                else
                                {
                                    dp = int.Parse(p1); d = 1;// MessageBox.Show(dp.ToString());
                                }

                                if (p2 == "-")
                                    kurs = 0;
                                else
                                {
                                    kurs = int.Parse(p2); k = 1; //MessageBox.Show(kurs.ToString());
                                }

                                comprogres.Parameters.AddWithValue("std", std);
                                comprogres.Parameters.AddWithValue("dis", dis);
                                if(z==1)
                                {
                                    sr_gr +=55+ int.Parse(comprogres.ExecuteScalar().ToString()) + dp + kurs;
                                }
                                else
                                    sr_gr +=int.Parse(comprogres.ExecuteScalar().ToString()) + dp + kurs; //MessageBox.Show("gr - "+name); MessageBox.Show("stud: "+std); MessageBox.Show("sr= "+sr_gr.ToString());
                                comcd.Parameters.Clear(); comz.Parameters.Clear(); comprogres.Parameters.Clear(); comprogres2.Parameters.Clear(); comprogres3.Parameters.Clear();
                            }
                            comc3.Parameters.Clear(); comc4.Parameters.Clear();
                        }

                        
                        comstd.Parameters.Clear(); coms.Parameters.Clear(); 
                    }

                    glist.label1.Text = name; glist.lt = name;glist.grp = gr_id;
                    if (sr_gr == 0 || count2==0)
                    {
                        //  sr_gr = 60; count1 = 3;
                        count2 = 0;
                    }


                    
                    //MessageBox.Show(sr_gr.ToString());

                    gpanel.Controls.Add(glist);
                    /////////////////////// ГРАФИК ГРУП ///////////////////////////////
                    chart1.Update();
                    chart1.Series.Add(i.ToString()); chart1.ChartAreas[0].AxisY.Maximum = 100;
                    if ( count2 == 0)
                        chart1.Series[i].Points.AddXY(i, 0);
                    else
                    {   
                        if(d==1 || k==1)
                            chart1.Series[i].Points.AddXY(i, (sr_gr / count1/count2)/2);
                        if(d == 1 && k == 1)
                            chart1.Series[i].Points.AddXY(i, (sr_gr / count1 / count2) / 3);
                        if (d == 0 && k == 0)
                        {
                            chart1.Series[i].Points.AddXY(i, sr_gr / count1 / count2);
                        }
                           
                    }
                    

                    chart1.Series[i].Points[0].AxisLabel = name;

                    chart1.ChartAreas[0].AxisX.Title = "Номер групи";
                    chart1.ChartAreas[0].AxisY.Title = "Середній бал групи";
                    chart1.ChartAreas[0].AxisX.Interval = 1; //glist.col = chart1.Series[i].Color; 
                    com.Parameters.Clear(); comstd.Parameters.Clear(); comsc.Parameters.Clear(); comc1.Parameters.Clear(); comc2.Parameters.Clear(); comc.Parameters.Clear();//comprogres.Parameters.Clear();

                }
                
            }

        }

        void esize(ControlTab glist)
        {
            glist.label1.Location = new Point(glist.Width / 20, glist.label1.Location.Y);
            glist.label3.Location = new Point(glist.Width / 34, glist.label3.Location.Y);
        }

        private void diplom_SizeChanged(object sender, EventArgs e)
        {
           /* grouppanel.Width = Width / 3;
            studentpanel.Width = Width / 3;
            personalpanel.Width = Width / 3;
            label1.Location = new Point(panel1.Width / 82, label1.Location.Y);
            label4.Location = new Point(panel3.Width / 82, label4.Location.Y);
            /abel6.Location = new Point(ppanel.Width / 82, label6.Location.Y);
            label2.Location = new Point(panel1.Width / 3 + panel1.Width / 17, label2.Location.Y);
            label3.Location = new Point(panel3.Width / 3 + panel3.Width / 17, label3.Location.Y);
            label5.Location = new Point(ppanel.Width / 3 + ppanel.Width / 17, label5.Location.Y);
            gpanel.Width = grouppanel.Width;
            panell.Width = studentpanel.Width;
            panel4.Width = personalpanel.Width;*/
        }
    }

 }

