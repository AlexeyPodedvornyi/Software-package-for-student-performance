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
    public partial class adm_grp : Form
    {
        public adm_grp()
        {
            InitializeComponent();
        }

        public int Regex_gr(TextBox tb, ref int j) //проверка на ФИ
        {
            string ra_gr9 = @"^[0-9]{3}\-[0-9]{2}\-[1-2]$"; Regex regex9 = new Regex(ra_gr9);
            string ra_gr11 = @"^[0-9]{3}\-[0-9]{2}\-[1-2]$"; Regex regex11 = new Regex(ra_gr11);
            if (regex9.IsMatch(tb.Text) == false && regex11.IsMatch(tb.Text) == false )
            {
                DialogResult result = MessageBox.Show(
                "Помилкове значення для поля 'Номер групи'!\nНомер групи не відповідає формату 'gr'",
                "Помилка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1); j = 1;
            }
            return j;
        }

        private void adm_grp_Load(object sender, EventArgs e)
        {
            tabl.AllowUserToAddRows = false;    /////ЗАПРЩАЕМ ПОЛЬЗОВАТЕЛЯМ ДОБАВЛЯТЬ СТРОЧКИ КЛИКОМ НА ПОЛЕ
            tabl.AllowUserToDeleteRows = false; ////ЗАПРЩАЕМ ПОЛЬЗОВАТЕЛЯМ УДАЛЯТЬ СТРОЧКИ КЛИКОМ НА ПОЛЕtabl.Font.Size = 10;
            tabl.ReadOnly = true;               ////АКТИВИРУЕМ РЕЖИМ ТОЛЬКО ЧТЕНИЕ
                                                // tabl.Font.Size = 10;
            comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; ////////// ЗАПРЕТ РУЧНОГО ВВОДА В ВЫПАДАЮЩИЙ СПИСОК
            comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;////АКТИВИРУЕМ РЕЖИМ ТОЛЬКО ЧТЕНИЕ
            comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox7.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox8.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            // a_box4.Enabled = false; a_box4.Text = "0";
            //e_box4.Enabled = false;
            // ВЫВОД ТАБЛИЦЫ
            if (checkBox1.CheckState == CheckState.Checked)
            {
                chl2(); button1.Enabled = false; button2.Enabled = false; button3.Enabled = false;
            }
            else
            {
                chl1(); button4.Enabled = false; button5.Enabled = false; button6.Enabled = false;
            }
        }

        private void refresh_but_Click(object sender, EventArgs e)
        {
            if (checkBox1.CheckState == CheckState.Checked)
            {
                chl2();
            }
            else
            {
                chl1(); 
            }
        }

        void chl1()
        {
            DataTable dt = new DataTable();

            using (Form1.MC)
            {
                MySqlCommand com = new MySqlCommand("select g_roups.id_grp as 'Номер групи', branches.br_name as 'Номер відділення', " +
                    "staff.fio as 'Голова комісії', g_roups.com as 'Номер комісії' from g_roups,branches,staff where g_roups.id_b=branches.id_b and g_roups.id_p=staff.id_p", Form1.MC);
                MySqlCommand com1 = new MySqlCommand("select br_name from branches", Form1.MC);
                MySqlCommand com2 = new MySqlCommand("select fio from staff where pos=2", Form1.MC);
                MySqlCommand com3 = new MySqlCommand("select id_grp from g_roups", Form1.MC);
                if (Form1.MC.State == ConnectionState.Closed)
                    Form1.MC.Open();
                MySqlDataReader rd = com.ExecuteReader();// MySqlDataReader rd1 = com.ExecuteReader(); MySqlDataReader rd2 = com.ExecuteReader();
                dt.Load(rd);

                if (dt.Rows.Count > 0)
                {
                    tabl.DataSource = dt;
                }

                rd = com1.ExecuteReader(); //rd1 = com2.ExecuteReader(); rd1 = com3.ExecuteReader();
                comboBox1.Items.Clear(); comboBox2.Items.Clear(); comboBox3.Items.Clear(); comboBox4.Items.Clear(); comboBox5.Items.Clear(); comboBox6.Items.Clear();
                while (rd.Read())
                {
                    comboBox3.Items.Add(Convert.ToString(rd["br_name"]));
                    comboBox6.Items.Add(Convert.ToString(rd["br_name"]));
                }
                rd.Close();
                //comboBox2.Items.Add(Convert.ToInt32(rd["id_client"]));
                rd = com2.ExecuteReader();

                while (rd.Read())
                {
                    comboBox4.Items.Add(Convert.ToString(rd["fio"]));
                    comboBox5.Items.Add(Convert.ToString(rd["fio"]));
                }

                rd.Close();
                rd = com3.ExecuteReader();
                while (rd.Read())
                {
                    comboBox1.Items.Add(Convert.ToString(rd["id_grp"]));
                    comboBox2.Items.Add(Convert.ToString(rd["id_grp"]));
                }
                rd.Close();
            }
        }

        void chl2()
        {
            DataTable dt = new DataTable();

            using (Form1.MC2)
            {
                MySqlCommand com = new MySqlCommand("select g_roups.id_grp as 'Номер групи', branches.br_name as 'Номер відділення', " +
                    "staff.fio as 'Голова комісії', g_roups.com as 'Номер комісії' from g_roups,branches,staff where g_roups.id_b=branches.id_b and g_roups.id_p=staff.id_p", Form1.MC2);
                MySqlCommand com1 = new MySqlCommand("select br_name from branches", Form1.MC2);
                MySqlCommand com2 = new MySqlCommand("select fio from staff where pos=2", Form1.MC2);
                MySqlCommand com3 = new MySqlCommand("select id_grp from g_roups", Form1.MC2);
                if (Form1.MC2.State == ConnectionState.Closed)
                    Form1.MC2.Open();
                MySqlDataReader rd = com.ExecuteReader();// MySqlDataReader rd1 = com.ExecuteReader(); MySqlDataReader rd2 = com.ExecuteReader();
                dt.Load(rd);

                if (dt.Rows.Count > 0)
                {
                    tabl.DataSource = dt;
                }

                rd = com1.ExecuteReader(); //rd1 = com2.ExecuteReader(); rd1 = com3.ExecuteReader();
                comboBox1.Items.Clear(); comboBox2.Items.Clear(); comboBox3.Items.Clear(); comboBox4.Items.Clear(); comboBox5.Items.Clear(); comboBox6.Items.Clear();
                while (rd.Read())
                {
                    comboBox3.Items.Add(Convert.ToString(rd["br_name"]));
                    comboBox6.Items.Add(Convert.ToString(rd["br_name"]));
                }
                rd.Close();
                //comboBox2.Items.Add(Convert.ToInt32(rd["id_client"]));
                rd = com2.ExecuteReader();

                while (rd.Read())
                {
                    comboBox4.Items.Add(Convert.ToString(rd["fio"]));
                    comboBox5.Items.Add(Convert.ToString(rd["fio"]));
                }

                rd.Close();
                rd = com3.ExecuteReader();
                while (rd.Read())
                {
                    comboBox1.Items.Add(Convert.ToString(rd["id_grp"]));
                    comboBox2.Items.Add(Convert.ToString(rd["id_grp"]));
                }
                rd.Close();
            }
        }

        void chr1()
        {
            DataTable dt = new DataTable();

            using (Form1.MC)
            {
                MySqlCommand com = new MySqlCommand("select g_roups.id_grp as 'Номер групи', branches.br_name as 'Номер відділення', " +
                    "staff.fio as 'Голова комісії', g_roups.com as 'Номер комісії' from g_roups,branches,staff where g_roups.id_b=branches.id_b and g_roups.id_p=staff.id_p", Form1.MC);
                MySqlCommand com1 = new MySqlCommand("select br_name from branches", Form1.MC);
                MySqlCommand com2 = new MySqlCommand("select fio from staff where pos=2", Form1.MC);
                MySqlCommand com3 = new MySqlCommand("select id_grp from g_roups", Form1.MC);
                if (Form1.MC.State == ConnectionState.Closed)
                    Form1.MC.Open();
                MySqlDataReader rd = com.ExecuteReader();// MySqlDataReader rd1 = com.ExecuteReader(); MySqlDataReader rd2 = com.ExecuteReader();
                dt.Load(rd);

                if (dt.Rows.Count > 0)
                {
                    tabl.DataSource = dt;
                }

                rd = com1.ExecuteReader(); //rd1 = com2.ExecuteReader(); rd1 = com3.ExecuteReader();
                comboBox1.Items.Clear(); comboBox2.Items.Clear(); comboBox3.Items.Clear(); comboBox4.Items.Clear(); comboBox5.Items.Clear(); comboBox6.Items.Clear();
                while (rd.Read())
                {
                    comboBox3.Items.Add(Convert.ToString(rd["br_name"]));
                    comboBox6.Items.Add(Convert.ToString(rd["br_name"]));
                }
                rd.Close();
                //comboBox2.Items.Add(Convert.ToInt32(rd["id_client"]));
                rd = com2.ExecuteReader();

                while (rd.Read())
                {
                    comboBox4.Items.Add(Convert.ToString(rd["fio"]));
                    comboBox5.Items.Add(Convert.ToString(rd["fio"]));
                }

                rd.Close();
                rd = com3.ExecuteReader();
                while (rd.Read())
                {
                    comboBox1.Items.Add(Convert.ToString(rd["id_grp"]));
                    comboBox2.Items.Add(Convert.ToString(rd["id_grp"]));
                }
                rd.Close();
            }
        }

        void chr2()
        {
            DataTable dt = new DataTable();

            using (Form1.MC2)
            {
                MySqlCommand com = new MySqlCommand("select g_roups.id_grp as 'Номер групи', branches.br_name as 'Номер відділення', " +
                    "staff.fio as 'Голова комісії', g_roups.com as 'Номер комісії' from g_roups,branches,staff where g_roups.id_b=branches.id_b and g_roups.id_p=staff.id_p", Form1.MC2);
                MySqlCommand com1 = new MySqlCommand("select br_name from branches", Form1.MC2);
                MySqlCommand com2 = new MySqlCommand("select fio from staff where pos=2", Form1.MC2);
                MySqlCommand com3 = new MySqlCommand("select id_grp from g_roups", Form1.MC2);
                if (Form1.MC2.State == ConnectionState.Closed)
                    Form1.MC2.Open();
                MySqlDataReader rd = com.ExecuteReader();// MySqlDataReader rd1 = com.ExecuteReader(); MySqlDataReader rd2 = com.ExecuteReader();
                dt.Load(rd);

                if (dt.Rows.Count > 0)
                {
                    tabl.DataSource = dt;
                }

                rd = com1.ExecuteReader(); //rd1 = com2.ExecuteReader(); rd1 = com3.ExecuteReader();
                comboBox1.Items.Clear(); comboBox2.Items.Clear(); comboBox3.Items.Clear(); comboBox4.Items.Clear(); comboBox5.Items.Clear(); comboBox6.Items.Clear();
                while (rd.Read())
                {
                    comboBox3.Items.Add(Convert.ToString(rd["br_name"]));
                    comboBox6.Items.Add(Convert.ToString(rd["br_name"]));
                }
                rd.Close();
                //comboBox2.Items.Add(Convert.ToInt32(rd["id_client"]));
                rd = com2.ExecuteReader();

                while (rd.Read())
                {
                    comboBox4.Items.Add(Convert.ToString(rd["fio"]));
                    comboBox5.Items.Add(Convert.ToString(rd["fio"]));
                }

                rd.Close();
                rd = com3.ExecuteReader();
                while (rd.Read())
                {
                    comboBox1.Items.Add(Convert.ToString(rd["id_grp"]));
                    comboBox2.Items.Add(Convert.ToString(rd["id_grp"]));
                }
                rd.Close();
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            b1c();
           // b1c2();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            b2c();
            //b2c2();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            b3c();
          //  b3c2();
        }

        void b1c()
        {
            string a, b, c, d, prov; int j = 0; prov = ""; int num; bool isNum1 = int.TryParse(a_box2.Text.Trim(), out num);
            a = a_box2.Text;
            b = Convert.ToString(comboBox3.SelectedItem);
            c = Convert.ToString(comboBox4.SelectedItem);
            d = Convert.ToString(comboBox7.SelectedItem);


            MySqlCommand com = new MySqlCommand("insert into g_roups values (@a,@b,@c,@d)", Form1.MC);
            MySqlCommand com2 = new MySqlCommand("select id_p from staff where fio=@c", Form1.MC);
            MySqlCommand com3 = new MySqlCommand("select id_b from branches where br_name=@b", Form1.MC);
            MySqlCommand comc2 = new MySqlCommand("select count(*) from g_roups where id_grp = @a", Form1.MC);

            if (Form1.MC.State == System.Data.ConnectionState.Closed)
                Form1.MC.Open();
            if (a.Length == 0 || b.Length == 0 || c.Length == 0 || d.Length == 0)
            {
                DialogResult ans = MessageBox.Show(
              "Поля не можуть бути порожніми! Необхідно заповнити усі поля",
              "Помилка",
               MessageBoxButtons.OK,
               MessageBoxIcon.Error,
               MessageBoxDefaultButton.Button1);
                return;
            }

            Regex_gr(a_box2, ref j);
            if (j == 1)
                return;

            com2.Parameters.AddWithValue("c", c);
            com3.Parameters.AddWithValue("b", b);
            c = com2.ExecuteScalar().ToString();
            b = com3.ExecuteScalar().ToString();
            comc2.Parameters.AddWithValue("a", a);
            int c2 = int.Parse(comc2.ExecuteScalar().ToString());
            if (c2 > 0)
            {
                DialogResult ans = MessageBox.Show(
                               "Група з таким номером вже існує!",
                               "Помилка",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error,
                                MessageBoxDefaultButton.Button1);
                return;
            }

            com.Parameters.AddWithValue("a", a);
            com.Parameters.AddWithValue("b", b);
            com.Parameters.AddWithValue("c", c);
            com.Parameters.AddWithValue("d", d);
            com.ExecuteNonQuery(); com.Parameters.Clear(); com2.Parameters.Clear(); com3.Parameters.Clear(); comc2.Parameters.Clear();
        }
        void b1c2()
        {
            string a, b, c, d, prov; int j = 0; prov = ""; int num; bool isNum1 = int.TryParse(a_box2.Text.Trim(), out num);
            a = a_box2.Text;
            b = Convert.ToString(comboBox3.SelectedItem);
            c = Convert.ToString(comboBox4.SelectedItem);
            d = Convert.ToString(comboBox7.SelectedItem);


            MySqlCommand com = new MySqlCommand("insert into g_roups values (@a,@b,@c,@d)", Form1.MC2);
            MySqlCommand com2 = new MySqlCommand("select id_p from staff where fio=@c", Form1.MC2);
            MySqlCommand com3 = new MySqlCommand("select id_b from branches where br_name=@b", Form1.MC2);
            MySqlCommand comc2 = new MySqlCommand("select count(*) from g_roups where id_grp = @a", Form1.MC2);

            if (Form1.MC2.State == System.Data.ConnectionState.Closed)
                Form1.MC2.Open();
            if (a.Length == 0 || b.Length == 0 || c.Length == 0 || d.Length == 0)
            {
               DialogResult ans = MessageBox.Show(
              "Поля не можуть бути порожніми! Необхідно заповнити усі поля",
              "Помилка",
               MessageBoxButtons.OK,
               MessageBoxIcon.Error,
               MessageBoxDefaultButton.Button1);
                return;
            }

            Regex_gr(a_box2, ref j);
            if (j == 1)
                return;

            com2.Parameters.AddWithValue("c", c);
            com3.Parameters.AddWithValue("b", b);
            c = com2.ExecuteScalar().ToString();
            b = com3.ExecuteScalar().ToString();
            comc2.Parameters.AddWithValue("a", a);
            int c2 = int.Parse(comc2.ExecuteScalar().ToString());
            if (c2 > 0)
            {
                DialogResult ans = MessageBox.Show(
                               "Група з таким номером вже існує!",
                               "Помилка",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error,
                                MessageBoxDefaultButton.Button1);
                return;
            }

            com.Parameters.AddWithValue("a", a);
            com.Parameters.AddWithValue("b", b);
            com.Parameters.AddWithValue("c", c);
            com.Parameters.AddWithValue("d", d);
            com.ExecuteNonQuery(); com.Parameters.Clear(); com2.Parameters.Clear(); com3.Parameters.Clear(); comc2.Parameters.Clear();
        }
        void b2c()
        {
            string a, b, c, d, f, prov; int j = 0; prov = ""; int num; bool isNum1 = int.TryParse(a_box2.Text.Trim(), out num);
            a = e_box2.Text;
            b = Convert.ToString(comboBox6.SelectedItem);
            c = Convert.ToString(comboBox5.SelectedItem);
            d = Convert.ToString(comboBox1.SelectedItem);
            f = Convert.ToString(comboBox8.SelectedItem);

            MySqlCommand com = new MySqlCommand("update g_roups set id_grp=@a, id_b=@b, id_p=@c,com=@f where id_grp=@d", Form1.MC);
            MySqlCommand com2 = new MySqlCommand("select id_p from staff where fio=@c", Form1.MC);
            MySqlCommand com3 = new MySqlCommand("select id_b from branches where br_name=@b", Form1.MC);
            MySqlCommand comc = new MySqlCommand("select count(*) from students where id_grp = @d", Form1.MC);
            MySqlCommand comc2 = new MySqlCommand("select count(*) from g_roups where id_grp = @a", Form1.MC);
            if (Form1.MC.State == System.Data.ConnectionState.Closed)
                Form1.MC.Open();
            if (a.Length == 0 || b.Length == 0 || d.Length == 0 || c.Length == 0 || f.Length == 0)
            {
                DialogResult ans = MessageBox.Show(
               "Поля не можуть бути порожніми! Необхідно заповнити усі поля",
               "Помилка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1);
                return;
            }

            Regex_gr(e_box2, ref j);
            if (j == 1)
                return;

            com2.Parameters.AddWithValue("c", c);
            com3.Parameters.AddWithValue("b", b);
            c = com2.ExecuteScalar().ToString();
            b = com3.ExecuteScalar().ToString();
            comc2.Parameters.AddWithValue("a", a);
            int c2 = int.Parse(comc2.ExecuteScalar().ToString());
            if(c2>0)
            {
                DialogResult ans = MessageBox.Show(
                               "Група з таким номером вже існує!",
                               "Помилка",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error,
                                MessageBoxDefaultButton.Button1);
                return;
            }
            com.Parameters.AddWithValue("a", a);
            com.Parameters.AddWithValue("b", b);
            com.Parameters.AddWithValue("c", c);
            com.Parameters.AddWithValue("d", d);
            com.Parameters.AddWithValue("f", f);

            comc.Parameters.AddWithValue("d", d);
            int c1 = int.Parse(comc.ExecuteScalar().ToString());//MessageBox.Show(c1.ToString());
            if (c1 > 0)
            {
                DialogResult ans = MessageBox.Show(
              "Записи про цю групу містяться у інших таблиця!\nДля збереження цілісності структуру БД необхідно спершу видалити запис з інших таблиць (Керування студентами)!",
              "Неможливо редагувати запис про групу",
               MessageBoxButtons.OK,
               MessageBoxIcon.Error,
               MessageBoxDefaultButton.Button1);
                return;
            }
            com.ExecuteNonQuery(); com.Parameters.Clear(); com2.Parameters.Clear(); com3.Parameters.Clear(); comc.Parameters.Clear(); comc2.Parameters.Clear();

        }
        void b2c2()
        {
            string a, b, c, d, f, prov; int j = 0; prov = ""; int num; bool isNum1 = int.TryParse(a_box2.Text.Trim(), out num);
            a = e_box2.Text;
            b = Convert.ToString(comboBox6.SelectedItem);
            c = Convert.ToString(comboBox5.SelectedItem);
            d = Convert.ToString(comboBox1.SelectedItem);
            f = Convert.ToString(comboBox8.SelectedItem);

            MySqlCommand com = new MySqlCommand("update g_roups set id_grp=@a, id_b=@b, id_p=@c,com=@f where id_grp=@d", Form1.MC2);
            MySqlCommand com2 = new MySqlCommand("select id_p from staff where fio=@c", Form1.MC2);
            MySqlCommand com3 = new MySqlCommand("select id_b from branches where br_name=@b", Form1.MC2);
            MySqlCommand comc = new MySqlCommand("select count(*) from students where id_grp = @d", Form1.MC2);
            MySqlCommand comc2 = new MySqlCommand("select count(*) from g_roups where id_grp = @a", Form1.MC2);

            if (Form1.MC2.State == System.Data.ConnectionState.Closed)
                Form1.MC2.Open();
            if (a.Length == 0 || b.Length == 0 || d.Length == 0 || c.Length == 0 || f.Length == 0)
            {
                DialogResult ans = MessageBox.Show(
               "Поля не можуть бути порожніми! Необхідно заповнити усі поля",
               "Помилка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1);
                return;
            }

            Regex_gr(e_box2, ref j);
            if (j == 1)
                return;

            com2.Parameters.AddWithValue("c", c);
            com3.Parameters.AddWithValue("b", b);
            c = com2.ExecuteScalar().ToString();
            b = com3.ExecuteScalar().ToString();
            comc2.Parameters.AddWithValue("a", a);
            int c2 = int.Parse(comc2.ExecuteScalar().ToString());
            if (c2 > 0)
            {
                DialogResult ans = MessageBox.Show(
                               "Група з таким номером вже існує!",
                               "Помилка",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error,
                                MessageBoxDefaultButton.Button1);
                return;
            }

            com.Parameters.AddWithValue("a", a);
            com.Parameters.AddWithValue("b", b);
            com.Parameters.AddWithValue("c", c);
            com.Parameters.AddWithValue("d", d);
            com.Parameters.AddWithValue("f", f);

            comc.Parameters.AddWithValue("d", d);
            int c1 = int.Parse(comc.ExecuteScalar().ToString());
            if (c1 > 0)
            {
                DialogResult ans = MessageBox.Show(
              "Записи про цю групу містяться у інших таблиця!\nДля збереження цілісності структуру БД необхідно спершу видалити запис з інших таблиць (Керування студентами)!",
              "Неможливо редагувати запис про групу",
               MessageBoxButtons.OK,
               MessageBoxIcon.Error,
               MessageBoxDefaultButton.Button1);
                return;
            }
            com.ExecuteNonQuery(); com.Parameters.Clear(); com2.Parameters.Clear(); com3.Parameters.Clear(); comc.Parameters.Clear(); comc2.Parameters.Clear();
        }
        void b3c()
        {
            string a;
            a = Convert.ToString(comboBox2.SelectedItem);

            MySqlCommand com = new MySqlCommand("delete from g_roups where id_grp = @a", Form1.MC);
            MySqlCommand comc = new MySqlCommand("select count(*) from students where id_grp = @a", Form1.MC);

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
            com.Parameters.AddWithValue("a", a); comc.Parameters.AddWithValue("a", a);
            int c1 = int.Parse(comc.ExecuteScalar().ToString());
            if (c1 > 0 )
            {
                DialogResult ans = MessageBox.Show(
              "Записи про цю групу містяться у інших таблиця!\nДля збереження цілісності структуру БД необхідно спершу видалити запис з інших таблиць (Керування студентами)!",
              "Неможливо видалити групу",
               MessageBoxButtons.OK,
               MessageBoxIcon.Error,
               MessageBoxDefaultButton.Button1);
                return;
            }
            com.ExecuteNonQuery(); com.Parameters.Clear(); comc.Parameters.Clear();
        }
        void b3c2()
        {
            string a;
            a = Convert.ToString(comboBox2.SelectedItem);

            MySqlCommand com = new MySqlCommand("delete from g_roups where id_grp = @a", Form1.MC2);
            MySqlCommand comc = new MySqlCommand("select count(*) from students where id_grp = @a", Form1.MC2);

            if (Form1.MC2.State == System.Data.ConnectionState.Closed)
                Form1.MC2.Open();
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
            com.Parameters.AddWithValue("a", a); comc.Parameters.AddWithValue("a", a);
            int c1 = int.Parse(comc.ExecuteScalar().ToString());
            if (c1 > 0)
            {
                DialogResult ans = MessageBox.Show(
              "Записи про цю групу містяться у інших таблиця!\nДля збереження цілісності структуру БД необхідно спершу видалити запис з інших таблиць (Керування студентами)!",
              "Неможливо видалити групу",
               MessageBoxButtons.OK,
               MessageBoxIcon.Error,
               MessageBoxDefaultButton.Button1);
                return;
            }
            com.ExecuteNonQuery(); com.Parameters.Clear(); comc.Parameters.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            b1c2();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            b2c2();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            b3c2();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.CheckState == CheckState.Checked)
            {
                chr2();
                button1.Enabled = false; button2.Enabled = false; button3.Enabled = false;
                button4.Enabled = true; button5.Enabled = true; button6.Enabled = true;
            }
            else
            {
                chr1();
                button4.Enabled = false; button5.Enabled = false; button6.Enabled = false;
                button1.Enabled = true; button2.Enabled = true; button3.Enabled = true;
            }
        }
    }
}
