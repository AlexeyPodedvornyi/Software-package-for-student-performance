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
    public partial class adm_author : Form
    {
        public adm_author()
        {
            InitializeComponent();
        }

        private void adm_author_Load(object sender, EventArgs e)
        {
            tabl.AllowUserToAddRows = false;    /////ЗАПРЩАЕМ ПОЛЬЗОВАТЕЛЯМ ДОБАВЛЯТЬ СТРОЧКИ КЛИКОМ НА ПОЛЕ
            tabl.AllowUserToDeleteRows = false; ////ЗАПРЩАЕМ ПОЛЬЗОВАТЕЛЯМ УДАЛЯТЬ СТРОЧКИ КЛИКОМ НА ПОЛЕtabl.Font.Size = 10;
            tabl.ReadOnly = true;               ////АКТИВИРУЕМ РЕЖИМ ТОЛЬКО ЧТЕНИЕ
                                                // tabl.Font.Size = 10;
            comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; ////////// ЗАПРЕТ РУЧНОГО ВВОДА В ВЫПАДАЮЩИЙ СПИСОК
            comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;////АКТИВИРУЕМ РЕЖИМ ТОЛЬКО ЧТЕНИЕ
            comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            // a_box4.Enabled = false; a_box4.Text = "0";
            //e_box4.Enabled = false;
            // ВЫВОД ТАБЛИЦЫ
            if (checkBox1.CheckState == CheckState.Checked)
            {
                chl2(); //button1.Enabled = false; //button2.Enabled = false; button3.Enabled = false;
            }
            else
            {
                chl1(); //button4.Enabled = false; button5.Enabled = false; button6.Enabled = false;
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
                MySqlCommand com = new MySqlCommand("select logim.login as 'Логін', logim.pass as 'Пароль', " +
                    "staff.fio as 'ПІБ викладача' from logim,staff where staff.id_p=logim.id_p", Form1.MC);
                // MySqlCommand com1 = new MySqlCommand("select id_p from logim", Form1.MC);
                MySqlCommand com2 = new MySqlCommand("select fio from staff", Form1.MC);
                MySqlCommand com1 = new MySqlCommand("select staff.fio from logim,staff where staff.id_p=logim.id_p", Form1.MC);
                //MySqlCommand com22 = new MySqlCommand("select id_p from staff", Form1.MC);
                if (Form1.MC.State == ConnectionState.Closed)
                    Form1.MC.Open();
                MySqlDataReader rd = com.ExecuteReader();// MySqlDataReader rd1 = com.ExecuteReader(); MySqlDataReader rd2 = com.ExecuteReader();
                dt.Load(rd);

                if (dt.Rows.Count > 0)
                {
                    tabl.DataSource = dt;
                }

                rd = com1.ExecuteReader(); //rd1 = com2.ExecuteReader(); rd1 = com3.ExecuteReader();
                comboBox1.Items.Clear(); comboBox2.Items.Clear(); comboBox3.Items.Clear();

                while (rd.Read())
                {
                    comboBox1.Items.Add(Convert.ToString(rd["fio"]));
                    comboBox2.Items.Add(Convert.ToString(rd["fio"]));
                }
                rd.Close();
                rd = com2.ExecuteReader();
                while (rd.Read())
                {
                    comboBox3.Items.Add(Convert.ToString(rd["fio"]));
                }
                rd.Close();
            }
        }
        void chl2()
        {
            DataTable dt = new DataTable();

            using (Form1.MC2)
            {
                MySqlCommand com = new MySqlCommand("select logim.login as 'Логін', logim.pass as 'Пароль', " +
                    "staff.fio as 'ПІБ викладача' from logim,staff where staff.id_p=logim.id_p", Form1.MC2);
                // MySqlCommand com1 = new MySqlCommand("select id_p from logim", Form1.MC);
                MySqlCommand com2 = new MySqlCommand("select fio from staff", Form1.MC2);
                MySqlCommand com1 = new MySqlCommand("select staff.fio from logim,staff where staff.id_p=logim.id_p", Form1.MC2);
                //MySqlCommand com22 = new MySqlCommand("select id_p from staff", Form1.MC);
                if (Form1.MC2.State == ConnectionState.Closed)
                    Form1.MC2.Open();
                MySqlDataReader rd = com.ExecuteReader();// MySqlDataReader rd1 = com.ExecuteReader(); MySqlDataReader rd2 = com.ExecuteReader();
                dt.Load(rd);

                if (dt.Rows.Count > 0)
                {
                    tabl.DataSource = dt;
                }

                rd = com1.ExecuteReader(); //rd1 = com2.ExecuteReader(); rd1 = com3.ExecuteReader();
                comboBox1.Items.Clear(); comboBox2.Items.Clear(); comboBox3.Items.Clear();

                while (rd.Read())
                {
                    comboBox1.Items.Add(Convert.ToString(rd["fio"]));
                    comboBox2.Items.Add(Convert.ToString(rd["fio"]));
                }
                rd.Close();
                rd = com2.ExecuteReader();
                while (rd.Read())
                {
                    comboBox3.Items.Add(Convert.ToString(rd["fio"]));
                }
                rd.Close();
            }
        }
        void chr1()
        {
            DataTable dt = new DataTable();

            using (Form1.MC)
            {
                MySqlCommand com = new MySqlCommand("select logim.login as 'Логін', logim.pass as 'Пароль', " +
                   "staff.fio as 'ПІБ викладача' from logim,staff where staff.id_p=logim.id_p", Form1.MC);
                // MySqlCommand com1 = new MySqlCommand("select id_p from logim", Form1.MC);
                MySqlCommand com2 = new MySqlCommand("select fio from staff", Form1.MC);
                MySqlCommand com1 = new MySqlCommand("select staff.fio from logim,staff where staff.id_p=logim.id_p", Form1.MC);
                if (Form1.MC.State == ConnectionState.Closed)
                    Form1.MC.Open();
                MySqlDataReader rd = com.ExecuteReader();// MySqlDataReader rd1 = com.ExecuteReader(); MySqlDataReader rd2 = com.ExecuteReader();
                dt.Load(rd);

                if (dt.Rows.Count > 0)
                {
                    tabl.DataSource = dt;
                }

                rd = com1.ExecuteReader(); //rd1 = com2.ExecuteReader(); rd1 = com3.ExecuteReader();
                comboBox1.Items.Clear(); comboBox2.Items.Clear(); comboBox3.Items.Clear();

                while (rd.Read())
                {
                    comboBox1.Items.Add(Convert.ToString(rd["fio"]));
                    comboBox2.Items.Add(Convert.ToString(rd["fio"]));
                }
                rd.Close();
                rd = com2.ExecuteReader();
                while (rd.Read())
                {
                    comboBox3.Items.Add(Convert.ToString(rd["fio"]));
                }
                rd.Close();
            }
        }
        void chr2()
        {
            DataTable dt = new DataTable();

            using (Form1.MC2)
            {
                MySqlCommand com = new MySqlCommand("select logim.login as 'Логін', logim.pass as 'Пароль', " +
                   "staff.fio as 'ПІБ викладача' from logim,staff where staff.id_p=logim.id_p", Form1.MC2);
                // MySqlCommand com1 = new MySqlCommand("select id_p from logim", Form1.MC);
                MySqlCommand com2 = new MySqlCommand("select fio from staff", Form1.MC2);
                MySqlCommand com1 = new MySqlCommand("select staff.fio from logim,staff where staff.id_p=logim.id_p", Form1.MC2);
                if (Form1.MC2.State == ConnectionState.Closed)
                    Form1.MC2.Open();
                MySqlDataReader rd = com.ExecuteReader();// MySqlDataReader rd1 = com.ExecuteReader(); MySqlDataReader rd2 = com.ExecuteReader();
                dt.Load(rd);

                if (dt.Rows.Count > 0)
                {
                    tabl.DataSource = dt;
                }

                rd = com1.ExecuteReader(); //rd1 = com2.ExecuteReader(); rd1 = com3.ExecuteReader();
                comboBox1.Items.Clear(); comboBox2.Items.Clear(); comboBox3.Items.Clear();

                while (rd.Read())
                {
                    comboBox1.Items.Add(Convert.ToString(rd["fio"]));
                    comboBox2.Items.Add(Convert.ToString(rd["fio"]));
                }
                rd.Close();
                rd = com2.ExecuteReader();
                while (rd.Read())
                {
                    comboBox3.Items.Add(Convert.ToString(rd["fio"]));
                }
                rd.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            b1c();
            b1c2();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            b2c();
            b2c2();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            b3c();
            b3c2();
        }
        void b1c()
        {
            string a, b, c, d, prov; int j = 0; prov = ""; int num; bool isNum1 = int.TryParse(a_box2.Text.Trim(), out num);
            a = a_box2.Text;
            b = a_box3.Text;
            c = Convert.ToString(comboBox3.SelectedItem);

            MySqlCommand com = new MySqlCommand("insert into logim values (@a,@b,@c)", Form1.MC);
            MySqlCommand com2 = new MySqlCommand("select id_p from staff where fio=@c", Form1.MC);
            //MySqlCommand com1 = new MySqlCommand("select count(*) from logim where id_p=@c", Form1.MC);

            if (Form1.MC.State == System.Data.ConnectionState.Closed)
                Form1.MC.Open();
            if (a.Length == 0 || b.Length == 0 || c.Length == 0)
            {
                DialogResult ans = MessageBox.Show(
               "Поля не можуть бути порожніми! Необхідно заповнити усі поля",
               "Помилка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1);
                return;
            }
            com2.Parameters.AddWithValue("c", c);
            c = com2.ExecuteScalar().ToString();

            com.Parameters.AddWithValue("a", a);
            com.Parameters.AddWithValue("b", b);
            com.Parameters.AddWithValue("c", c);
            com.ExecuteNonQuery(); com.Parameters.Clear(); com2.Parameters.Clear();
        }
        void b1c2()
        {
            string a, b, c, d, prov; int j = 0; prov = ""; int num; bool isNum1 = int.TryParse(a_box2.Text.Trim(), out num);
            a = a_box2.Text;
            b = a_box3.Text;
            c = Convert.ToString(comboBox3.SelectedItem);

            MySqlCommand com = new MySqlCommand("insert into logim values (@a,@b,@c)", Form1.MC2);
            MySqlCommand com2 = new MySqlCommand("select id_p from staff where fio=@c", Form1.MC2);
            //MySqlCommand com1 = new MySqlCommand("select count(*) from logim where id_p=@c", Form1.MC);

            if (Form1.MC2.State == System.Data.ConnectionState.Closed)
                Form1.MC2.Open();
            if (a.Length == 0 || b.Length == 0 || c.Length == 0)
            {
                DialogResult ans = MessageBox.Show(
               "Поля не можуть бути порожніми! Необхідно заповнити усі поля",
               "Помилка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1);
                return;
            }
            com2.Parameters.AddWithValue("c", c);
            c = com2.ExecuteScalar().ToString();

            com.Parameters.AddWithValue("a", a);
            com.Parameters.AddWithValue("b", b);
            com.Parameters.AddWithValue("c", c);
            com.ExecuteNonQuery(); com.Parameters.Clear(); com2.Parameters.Clear();
        }
        void b2c()
        {
            string a, b, c, d, f, prov; int j = 0; prov = ""; int num; bool isNum1 = int.TryParse(a_box2.Text.Trim(), out num);
            a = e_box2.Text;
            b = e_box3.Text;
            c = Convert.ToString(comboBox1.SelectedItem);


            MySqlCommand com = new MySqlCommand("update logim set login=@a, pass=@b where id_p=@c", Form1.MC);
            MySqlCommand com2 = new MySqlCommand("select id_p from staff where fio=@c", Form1.MC);


            if (Form1.MC.State == System.Data.ConnectionState.Closed)
                Form1.MC.Open();
            if (a.Length == 0 || b.Length == 0 || c.Length == 0)
            {
                DialogResult ans = MessageBox.Show(
               "Поля не можуть бути порожніми! Необхідно заповнити усі поля",
               "Помилка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1);
                return;
            }
            com2.Parameters.AddWithValue("c", c);
            c = com2.ExecuteScalar().ToString();

            com.Parameters.AddWithValue("a", a);
            com.Parameters.AddWithValue("b", b);
            com.Parameters.AddWithValue("c", c);

            com.ExecuteNonQuery(); com.Parameters.Clear(); com2.Parameters.Clear();
        }
        void b2c2()
        {
            string a, b, c, d, f, prov; int j = 0; prov = ""; int num; bool isNum1 = int.TryParse(a_box2.Text.Trim(), out num);
            a = e_box2.Text;
            b = e_box3.Text;
            c = Convert.ToString(comboBox1.SelectedItem);


            MySqlCommand com = new MySqlCommand("update logim set login=@a, pass=@b where id_p=@c", Form1.MC2);
            MySqlCommand com2 = new MySqlCommand("select id_p from staff where fio=@c", Form1.MC2);


            if (Form1.MC2.State == System.Data.ConnectionState.Closed)
                Form1.MC2.Open();
            if (a.Length == 0 || b.Length == 0 || c.Length == 0)
            {
               DialogResult ans = MessageBox.Show(
               "Поля не можуть бути порожніми! Необхідно заповнити усі поля",
               "Помилка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1);
                return;
            }
            com2.Parameters.AddWithValue("c", c);
            c = com2.ExecuteScalar().ToString();

            com.Parameters.AddWithValue("a", a);
            com.Parameters.AddWithValue("b", b);
            com.Parameters.AddWithValue("c", c);

            com.ExecuteNonQuery(); com.Parameters.Clear(); com2.Parameters.Clear();
        }
        void b3c()
        {
            string a;
            a = Convert.ToString(comboBox2.SelectedItem);

            MySqlCommand com = new MySqlCommand("delete from logim where id_p = @a", Form1.MC);
            MySqlCommand com2 = new MySqlCommand("select id_p from staff where fio=@a", Form1.MC);

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
            com2.Parameters.AddWithValue("a", a);
            a = com2.ExecuteScalar().ToString();
            com.Parameters.AddWithValue("a", a);
            com.ExecuteNonQuery(); com.Parameters.Clear(); com2.Parameters.Clear();
        }
        void b3c2()
        {
            string a;
            a = Convert.ToString(comboBox2.SelectedItem);

            MySqlCommand com = new MySqlCommand("delete from logim where id_p = @a", Form1.MC2);
            MySqlCommand com2 = new MySqlCommand("select id_p from staff where fio=@a", Form1.MC2);

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
            com2.Parameters.AddWithValue("a", a);
            a = com2.ExecuteScalar().ToString();
            com.Parameters.AddWithValue("a", a);
            com.ExecuteNonQuery(); com.Parameters.Clear(); com2.Parameters.Clear();
        }

       

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.CheckState == CheckState.Checked)
            {
                chr2();
               
            }
            else
            {
                chr1();
               
            }
        }
    }
}
