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
    public partial class ControlTab3 : UserControl
    {
        public string grn; public string id; public string chb; public string name; public string grp;
        public ControlTab3()
        {
            InitializeComponent();
        }


        MySqlConnection MC = Form1.MC;
        private void ControlTab3_SizeChanged(object sender, EventArgs e)
        {
            label1.Location = new Point(Width / 20, label1.Location.Y);

        }

        private void ControlTab3_Load(object sender, EventArgs e)
        {
            tabl.AllowUserToAddRows = false;    /////ЗАПРЩАЕМ ПОЛЬЗОВАТЕЛЯМ ДОБАВЛЯТЬ СТРОЧКИ КЛИКОМ НА ПОЛЕ
            tabl.AllowUserToDeleteRows = false; ////ЗАПРЩАЕМ ПОЛЬЗОВАТЕЛЯМ УДАЛЯТЬ СТРОЧКИ КЛИКОМ НА ПОЛЕtabl.Font.Size = 10;
            tabl.ReadOnly = true;               ////АКТИВИРУЕМ РЕЖИМ ТОЛЬКО ЧТЕНИЕ
            tabl.Visible = true;
            label1.Visible = false;
            if(checkBox1.CheckState==CheckState.Unchecked)
            {
                tabl.Visible = true;
                label1.Visible = false;
                vivod();
            }
            else
            {

                tabl.Visible = true;
                label1.Visible = false;
                vivodterms();
            }
            label3.Visible = true; label2.Visible = true;
            label3.Text = name;
 
        }

        void vivod()
        {   
            
            MySqlCommand com1 = new MySqlCommand("select progress.id_stud as '№ студента',students.fio as 'ПІБ',progress.PK1 as'ПК1',progress.MK1 as'МК1', progress.PK2 as 'ПК2'," +
                   " progress.MK2 as 'МК2', progress.dp as 'ДП', progress.kurs as 'КП' from progress, students where progress.id_stud = students.id_stud  and progress.id_dis = @name and students.id_grp=@grp", MC);
            MySqlCommand com2 = new MySqlCommand("select count(*) from progress, students where progress.id_stud = students.id_stud  and progress.id_dis = @name and students.id_grp=@grp", MC);
            MySqlCommand com3 = new MySqlCommand("select id_dis from disciplines where name = @name", MC);
            MySqlCommand comz = new MySqlCommand("select zalik from dis_groups where id_dis=@id and id_grp=@grp", MC);
            MySqlCommand come = new MySqlCommand("select ekzamen from dis_groups where id_dis=@id and id_grp=@grp", MC);
            if (Form1.MC.State == ConnectionState.Closed)
                Form1.MC.Open();
            using (MC)
            {
                com3.Parameters.AddWithValue("name", name);
                id = com3.ExecuteScalar().ToString();
                comz.Parameters.AddWithValue("grp", grp);
                comz.Parameters.AddWithValue("id", id);
                come.Parameters.AddWithValue("grp", grp);
                come.Parameters.AddWithValue("id", id);
                int z= int.Parse(comz.ExecuteScalar().ToString());
                int ekz= int.Parse(come.ExecuteScalar().ToString());
                if(z==1 && ekz==0)
                {
                    com1 = new MySqlCommand("select progress.id_stud as '№ студента',students.fio as 'ПІБ',progress.PK1 as'ПК1', progress.PK2 as 'ПК2'," +
                   " progress.dp as 'ДП', progress.kurs as 'КП' from progress, students where progress.id_stud = students.id_stud  and progress.id_dis = @name and students.id_grp=@grp", MC);
                }
                com1.Parameters.AddWithValue("name", id);
                com1.Parameters.AddWithValue("grp", grp);
                com2.Parameters.AddWithValue("name", id);
                com2.Parameters.AddWithValue("grp", grp);
                int c1 = int.Parse(com2.ExecuteScalar().ToString()); //MessageBox.Show(c1.ToString());
                if (c1 == 0 || c1 < 1)
                {
                    tabl.Visible = false; //MessageBox.Show(c1.ToString());
                    label1.Text = "База даних не містить жодних записів про дисципліну '" + name + "' для групи " + grn + "!\nСпробуйте додати записи про студентів групи " + grn + " до таблиці 'progress'";
                    label1.Visible = true;
                }
                else
                {
                    DataTable dt = new DataTable();
                    MySqlDataReader rd = com1.ExecuteReader();
                    dt.Load(rd);
                    if (dt.Rows.Count > 0)
                    {
                        tabl.DataSource = dt;
                    }
                }
                com1.Parameters.Clear(); com2.Parameters.Clear(); com3.Parameters.Clear(); come.Parameters.Clear(); comz.Parameters.Clear();
            }
                
        }

        void vivodterms()
        {
              MySqlCommand com1 = new MySqlCommand("select distinct terms.name as 'Нaзва контрольного терміну', disciplines.name as 'Назва дисципліни', term_dis.dat as 'Термін складання'"
         + "from terms, disciplines, term_dis,g_roups where term_dis.id_dis = disciplines.id_dis and term_dis.id_t = terms.id_t and term_dis.id_dis = @id and g_roups.id_grp = term_dis.id_grp and term_dis.id_grp=@grp", MC);
           // MySqlCommand com1 = new MySqlCommand("select terms.name as 'Нaзва контрольного терміну', disciplines.name as 'Назва дисципліни', term_dis.dat as 'Термін складання' " +
            //    "from terms, disciplines, term_dis where term_dis.id_dis = disciplines.id_dis and term_dis.id_t = terms.id_t", MC);
            MySqlCommand com2 = new MySqlCommand("select count(*) from term_dis where id_dis=@id and id_grp=@grp", MC);
            MySqlCommand com3 = new MySqlCommand("select id_dis from disciplines where name = @name", MC);

            if (Form1.MC.State == ConnectionState.Closed)
                Form1.MC.Open();
            using (MC)
            {
                com3.Parameters.AddWithValue("name", name);
                id = com3.ExecuteScalar().ToString();

                com1.Parameters.AddWithValue("id", id);
                com1.Parameters.AddWithValue("grp", grp);
                com2.Parameters.AddWithValue("id", id);
                com2.Parameters.AddWithValue("grp", grp);
                int c1 = int.Parse(com2.ExecuteScalar().ToString()); //MessageBox.Show(c1.ToString());
                if (c1 == 0 || c1 < 1)
                {
                    tabl.Visible = false; //MessageBox.Show(c1.ToString());
                    label1.Text = "База даних не містить жодних записів про дисципліну '" + name + "' для групи " + grn + "!\nСпробуйте додати записи про студентів групи " + grn + " до таблиці 'progress'";
                    label1.Visible = true;
                }
                else
                {
                    DataTable dt = new DataTable();
                    MySqlDataReader rd = com1.ExecuteReader();
                    dt.Load(rd);
                    if (dt.Rows.Count > 0)
                    {
                        tabl.DataSource = dt;
                    }
                }
                com1.Parameters.Clear(); com2.Parameters.Clear(); com3.Parameters.Clear();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.CheckState == CheckState.Unchecked)
            {
                tabl.Visible = true;
                label1.Visible = false;
                vivod();
            }
            else
            {
                tabl.Visible = true;
                label1.Visible = false;
                vivodterms();
            }
        }
    }
}
