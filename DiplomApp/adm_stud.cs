using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiplomApp
{
    public partial class adm_stud : Form
    {
        public adm_stud()
        {
            InitializeComponent();
        }
        public int Regex_fi(TextBox tb, ref int j) //проверка на ФИ
        {
            string ra_fi = @"^[А-ЯЁЇІЄҐ][а-яёїієґ]+\s[А-ЯЁЇІЄҐ]{1}\.[А-ЯЁЇІЄҐ]{1}\.$"; Regex regex = new Regex(ra_fi);
            if (regex.IsMatch(tb.Text) == false)
            {
                DialogResult result = MessageBox.Show(
                "Помилкове значення поля 'ПІБ студента'!\nПрізвище та ім'я не відповидають формату'fi'",
                "Помилка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1); j = 1;
            }
            return j;
        }
        public int Regex_tel(TextBox tb, ref int j) //проверка на тел
        {
            string ra_nom = @"^(\+380)[0-9]{9}$", s1;
            Regex regex = new Regex(ra_nom);
            if (regex.IsMatch(tb.Text) == false)
            {
                DialogResult result = MessageBox.Show(
                "Помилкове значення поля 'Номер телефону'!\nНомер телефону не відповідає формату 'nom'",
                "Помилка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1); j = 1; return j;
            }
            if (tb.Text.Length != 13)
            {
                DialogResult result = MessageBox.Show(
                "Помилкове значення поля 'Номер телефону'!\nНомер телефону повинен мати довжину в 13 символів включаючи код країни",
                "Помилка",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Error,
                 MessageBoxDefaultButton.Button1); j = 1; return j;
            }
            s1 = tb.Text.Substring(0, tb.Text.Length - 9); //+380
            if (s1 != "+380")
            {
                DialogResult result = MessageBox.Show(
                "Помилкове значення поля 'Номер телефону'!\nНомер телефону повинен починатися з '+380', якщо потрібен код другої країни - зверніться до адміністратора",
                "Помилка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1); j = 1; return j;
            }

            return j;
        }



        private void button1_Click(object sender, EventArgs e)
        {
           
            b1c(); //b1c2();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            b2c();//b2c2();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            b3c();//b3c2();
        }

        private void adm_stud_Load(object sender, EventArgs e)
        {
            tabl.AllowUserToAddRows = false;    /////ЗАПРЩАЕМ ПОЛЬЗОВАТЕЛЯМ ДОБАВЛЯТЬ СТРОЧКИ КЛИКОМ НА ПОЛЕ
            tabl.AllowUserToDeleteRows = false; ////ЗАПРЩАЕМ ПОЛЬЗОВАТЕЛЯМ УДАЛЯТЬ СТРОЧКИ КЛИКОМ НА ПОЛЕ
            tabl.ReadOnly = true;               ////АКТИВИРУЕМ РЕЖИМ ТОЛЬКО ЧТЕНИЕ
            comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; ////////// ЗАПРЕТ РУЧНОГО ВВОДА В ВЫПАДАЮЩИЙ СПИСОК
            comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;////АКТИВИРУЕМ РЕЖИМ ТОЛЬКО ЧТЕНИЕ
            comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            // a_box4.Enabled = false; a_box4.Text = "0";
            //e_box4.Enabled = false;
            // ВЫВОД ТАБЛИЦЫ

            chl1();


        }

        private void refresh_but_Click(object sender, EventArgs e)
        {
            chl1();

        }

        void chl1()
        {
            DataTable dt = new DataTable();

            using (Form1.MC)
            {
                MySqlCommand com = new MySqlCommand("select students.id_stud as 'Номер студента', students.fio as 'ПІБ студента', students.id_grp as 'Номер групи', " +
                    "students.ph_num as 'Номер телефону' from students", Form1.MC);
                MySqlCommand com1 = new MySqlCommand("select id_grp from g_roups", Form1.MC);
               // MySqlCommand com2 = new MySqlCommand("select fio from staff where pos =3", Form1.MC);
                MySqlCommand com3 = new MySqlCommand("select id_stud from students", Form1.MC);
                if (Form1.MC.State == ConnectionState.Closed)
                    Form1.MC.Open();
                MySqlDataReader rd = com.ExecuteReader();// MySqlDataReader rd1 = com.ExecuteReader(); MySqlDataReader rd2 = com.ExecuteReader();
                dt.Load(rd);

                if (dt.Rows.Count > 0)
                {
                    tabl.DataSource = dt;
                }

                rd = com1.ExecuteReader(); //rd1 = com2.ExecuteReader(); rd1 = com3.ExecuteReader();
                comboBox1.Items.Clear(); comboBox2.Items.Clear(); comboBox3.Items.Clear();  comboBox5.Items.Clear(); 
                while (rd.Read())
                {
                    comboBox3.Items.Add(Convert.ToString(rd["id_grp"]));
                    comboBox5.Items.Add(Convert.ToString(rd["id_grp"]));
                }
                rd.Close();
                //comboBox2.Items.Add(Convert.ToInt32(rd["id_client"]));

                rd = com3.ExecuteReader();
                while (rd.Read())
                {
                    comboBox1.Items.Add(Convert.ToInt32(rd["id_stud"]));
                    comboBox2.Items.Add(Convert.ToInt32(rd["id_stud"]));
                }
                rd.Close();
            }
        }


        /*void chr1()
        {
            DataTable dt = new DataTable();

            using (Form1.MC)
            {
                MySqlCommand com = new MySqlCommand("select students.id_stud as 'Номер студента', students.fio as 'ПІБ студента', students.id_grp as 'Номер групи', " +
                     "students.ph_num as 'Номер телефону', staff.fio as 'Керівник проєкта' from students,staff where students.leader=staff.id_p", Form1.MC);
                MySqlCommand com1 = new MySqlCommand("select id_grp from g_roups", Form1.MC);
                MySqlCommand com2 = new MySqlCommand("select fio from staff where pos =3", Form1.MC);
                MySqlCommand com3 = new MySqlCommand("select id_stud from students", Form1.MC);
                if (Form1.MC.State == ConnectionState.Closed)
                    Form1.MC.Open();
                MySqlDataReader rd = com.ExecuteReader();// MySqlDataReader rd1 = com.ExecuteReader(); MySqlDataReader rd2 = com.ExecuteReader();
                dt.Load(rd);

                if (dt.Rows.Count > 0)
                {
                    tabl.DataSource = dt;
                }

                rd = com1.ExecuteReader(); //rd1 = com2.ExecuteReader(); rd1 = com3.ExecuteReader();
                comboBox1.Items.Clear(); comboBox2.Items.Clear(); comboBox3.Items.Clear();  comboBox5.Items.Clear(); 
                while (rd.Read())
                {
                    comboBox3.Items.Add(Convert.ToString(rd["id_grp"]));
                    comboBox5.Items.Add(Convert.ToString(rd["id_grp"]));
                }
                rd.Close();
                //comboBox2.Items.Add(Convert.ToInt32(rd["id_client"]));
     
                rd = com3.ExecuteReader();
                while (rd.Read())
                {
                    comboBox1.Items.Add(Convert.ToInt32(rd["id_stud"]));
                    comboBox2.Items.Add(Convert.ToInt32(rd["id_stud"]));
                }
                rd.Close();
            }
        }*/

        void b1c()
        {
            string a, b, c, d, prov; int j = 0; prov = ""; int num; bool isNum1 = int.TryParse(a_box2.Text.Trim(), out num);
            a = a_box2.Text;
            b = Convert.ToString(comboBox3.SelectedItem);
            c = a_box3.Text;

            MySqlCommand com = new MySqlCommand("insert into students(`fio`, `id_grp`, `ph_num`) values (@a,@b,@c)", Form1.MC);
           
            //MySqlCommand com2 = new MySqlCommand("select id_p from staff where fio=@d", Form1.MC);
           // MySqlCommand com1 = new MySqlCommand("select count(*) from students where leader = @d", Form1.MC);
            MySqlCommand comvsid = new MySqlCommand("select id_stud from students where fio=@a", Form1.MC);
            //MySqlCommand comvs = new MySqlCommand("insert into cont_parts(id_stud) values (@a)", Form1.MC);


            if (Form1.MC.State == System.Data.ConnectionState.Closed)
                Form1.MC.Open();
            if (a.Length == 0 || b.Length == 0 || c.Length == 0 )
            {
                DialogResult ans = MessageBox.Show(
              "Поля не можуть бути порожніми! Необхідно заповнити усі поля",
              "Помилка",
               MessageBoxButtons.OK,
               MessageBoxIcon.Error,
               MessageBoxDefaultButton.Button1);
                return;
            }
            
             Regex_fi(a_box2, ref j);
             if (j == 1)
                 return;
             Regex_tel(a_box3, ref j);
             if (j == 1)
                 return;

            com.Parameters.AddWithValue("a", a);
            com.Parameters.AddWithValue("b", b);
            com.Parameters.AddWithValue("c", c);
 
            com.ExecuteNonQuery();
            com.Parameters.Clear(); 
        }
       
        void b2c()
        {
            string a, b, c, d, f, prov; int j = 0; prov = ""; int num; bool isNum1 = int.TryParse(a_box2.Text.Trim(), out num);
            a = e_box2.Text;
            b = Convert.ToString(comboBox5.SelectedItem);
            c = e_box3.Text;
            f = Convert.ToString(comboBox1.SelectedItem);

            MySqlCommand com = new MySqlCommand("update students set fio=@a, id_grp=@b, ph_num=@c where id_stud=@f", Form1.MC);

            if (Form1.MC.State == System.Data.ConnectionState.Closed)
                Form1.MC.Open();
            if (a.Length == 0 || b.Length == 0 || c.Length == 0 ||  f.Length == 0)
            {
                DialogResult ans = MessageBox.Show(
               "Поля не можуть бути порожніми! Необхідно заповнити усі поля",
               "Помилка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1);
                return;
            }

            Regex_fi(e_box2, ref j);
            if (j == 1)
                return;
            Regex_tel(e_box3, ref j);
            if (j == 1)
                return;



            com.Parameters.AddWithValue("a", a);
            com.Parameters.AddWithValue("b", b);
            com.Parameters.AddWithValue("c", c);
            com.Parameters.AddWithValue("f", f);
            com.ExecuteNonQuery(); com.Parameters.Clear(); 
        }
        
        void b3c()
        {
            string a;
            a = Convert.ToString(comboBox2.SelectedItem);

            MySqlCommand com = new MySqlCommand("delete from students where id_stud = @a", Form1.MC);
            MySqlCommand comc = new MySqlCommand("select count(*) from progress where id_stud = @a", Form1.MC);
            MySqlCommand comd = new MySqlCommand("delete from progress where id_stud = @a", Form1.MC);

            if (Form1.MC.State == System.Data.ConnectionState.Closed)
                Form1.MC.Open();
            if (a.Length == 0)
            {
                DialogResult ans = MessageBox.Show(
               "Поля не можуть бути порожніми! Необхідно заповнити усі поля",
               "Помилка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1);
                return;
            }
            comc.Parameters.AddWithValue("a", a);
            int c = int.Parse(comc.ExecuteScalar().ToString());
            if(c>0)
            {
                comd.Parameters.AddWithValue("a", a);
                comd.ExecuteNonQuery();
            }
            com.Parameters.AddWithValue("a", a);
            com.ExecuteNonQuery(); com.Parameters.Clear();
            comc.Parameters.Clear(); comd.Parameters.Clear();
        }
        
    }
}
