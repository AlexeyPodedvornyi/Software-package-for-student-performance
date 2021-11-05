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
    public partial class adm_mark : Form
    {
        public adm_mark()
        {
            InitializeComponent();
        }
        public int Regex_marks(TextBox tb,string cb ,ref int j) //проверка на ФИ
        {
           
            if (cb == "ПК1")
            {
                if (int.Parse(tb.Text) > 20)
                {
                    DialogResult res = MessageBox.Show(
                    "Недопустиме значення для поля 'Оцінка' відповідно до обраного терміна! У написі 'Пам'ятка' позачено відповідність балів для кожного терміну.",
                    "Помилка",
                     MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                     MessageBoxDefaultButton.Button1);
                    j = 1;
                }
                   
            }
            if (cb == "ПК2")
            {
                if (int.Parse(tb.Text) > 25)
                {
                    DialogResult res = MessageBox.Show(
                    "Недопустиме значення для поля 'Оцінка' відповідно до обраного терміна! У написі 'Пам'ятка' позачено відповідність балів для кожного терміну.",
                    "Помилка",
                     MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                     MessageBoxDefaultButton.Button1);
                    j = 1;
                    
                }
            }
            if (cb == "МК1")
            {
                if (int.Parse(tb.Text) > 25)
                {
                    DialogResult res = MessageBox.Show(
                    "Недопустиме значення для поля 'Оцінка' відповідно до обраного терміна! У написі 'Пам'ятка' позачено відповідність балів для кожного терміну.",
                    "Помилка",
                     MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                     MessageBoxDefaultButton.Button1);
                    j = 1;
                    
                }
            }
            if (cb == "МК2")
            {
                if (int.Parse(tb.Text) > 30)
                {
                    DialogResult res = MessageBox.Show(
                    "Недопустиме значення для поля 'Оцінка' відповідно до обраного терміна! У написі 'Пам'ятка' позачено відповідність балів для кожного терміну.",
                    "Помилка",
                     MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                     MessageBoxDefaultButton.Button1);
                    j = 1;
                    
                }
            }
            if (cb == "КП")
            {
                if (int.Parse(tb.Text) > 100)
                {
                    DialogResult res = MessageBox.Show(
                    "Недопустиме значення для поля 'Оцінка' відповідно до обраного терміна! У написі 'Пам'ятка' позачено відповідність балів для кожного терміну.",
                    "Помилка",
                     MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                     MessageBoxDefaultButton.Button1);
                    j = 1;
                   
                }
            }
            if (cb == "ДП")
            {
                if (int.Parse(tb.Text) > 100)
                {
                    DialogResult res = MessageBox.Show(
                    "Недопустиме значення для поля 'Оцінка' відповідно до обраного терміна! У написі 'Пам'ятка' позачено відповідність балів для кожного терміну.",
                    "Помилка",
                     MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                     MessageBoxDefaultButton.Button1);
                    j = 1;
                    
                }
            }
  
            return j;
        }

        string idp = Form1.p;
        void chl1()
        {
            comboBox5.Items.Clear();
            DataTable dt = new DataTable();
            //string grp, std;
            using (Form1.MC)
            {
                //MySqlCommand com12 = new MySqlCommand("select distinct g_roups.name as 'Група' ,progress.id_stud as '№ студента',students.fio as 'ПІБ студента', disciplines.name as 'Дисципліна', progress.PK1 as 'ПК1',progress.MK1 as 'МК1', progress.PK2 as 'ПК2', progress.MK2 as 'МК2'" +
                //   ", progress.kurs as 'КП', progress.dp as 'ДП' from progress,disciplines,students,g_roups where progress.id_dis=disciplines.id_dis and students.id_stud = progress.id_stud and students.id_grp=g_roups.id_grp ", Form1.MC);
                MySqlCommand com1 = new MySqlCommand("select distinct students.id_stud from students,dis_groups,staff " +
                    "where dis_groups.id_p = staff.id_p and students.id_grp = dis_groups.id_grp and dis_groups.id_p = @idp", Form1.MC);
                MySqlCommand com12 = new MySqlCommand("select g_roups.name as 'Група' ,progress.id_stud as '№ студента',students.fio as 'ПІБ студента', disciplines.name as 'Дисципліна'," +
                "progress.PK1 as 'ПК1', progress.MK1 as 'МК1', progress.PK2 as 'ПК2', progress.MK2 as 'МК2', progress.kurs as 'КП', progress.dp as 'ДП' " +
                "from progress, disciplines, students, g_roups, dis_groups, staff where progress.id_dis = disciplines.id_dis  and students.id_stud = progress.id_stud " +
                "and students.id_grp = g_roups.id_grp and dis_groups.id_dis = disciplines.id_dis  and dis_groups.id_grp = g_roups.id_grp and dis_groups.id_p = staff.id_p " +
                "and dis_groups.id_p = @idp", Form1.MC);
                MySqlCommand com2 = new MySqlCommand("select distinct progress.id_stud from progress,dis_groups,students,staff " +
                "where dis_groups.id_p = staff.id_p and students.id_grp = dis_groups.id_grp and progress.id_stud = students.id_stud and progress.id_dis = dis_groups.id_dis and dis_groups.id_p = @idp", Form1.MC);
                MySqlCommand com3 = new MySqlCommand("select distinct disciplines.name from disciplines,dis_groups,staff "+
                    "where dis_groups.id_p = staff.id_p and dis_groups.id_dis = disciplines.id_dis and dis_groups.id_p = @idp", Form1.MC);
                
                // MySqlCommand com4 = new MySqlCommand("select disciplines.name from disciplines,progress where disciplines.id_dis = progress.id_dis", Form1.MC);
                if (Form1.MC.State == ConnectionState.Closed)
                    Form1.MC.Open();
                com12.Parameters.AddWithValue("idp", idp);
                com1.Parameters.AddWithValue("idp", idp);
                com2.Parameters.AddWithValue("idp", idp);
                com3.Parameters.AddWithValue("idp", idp);
                MySqlDataReader rd = com12.ExecuteReader();// MySqlDataReader rd1 = com.ExecuteReader(); MySqlDataReader rd2 = com.ExecuteReader();
                dt.Load(rd);
                //MessageBox.Show(dt.Rows.Count.ToString());
               
                if (dt.Rows.Count > 0)
                {
                    tabl.DataSource = dt;
                }

                rd = com1.ExecuteReader(); //rd1 = com2.ExecuteReader(); rd1 = com3.ExecuteReader();
                comboBox1.Items.Clear(); comboBox2.Items.Clear(); comboBox3.Items.Clear(); comboBox6.Items.Clear(); comboBox7.Items.Clear(); comboBox8.Items.Clear(); comboBox9.Items.Clear(); comboBox10.Items.Clear();

                while (rd.Read())
                {
                    comboBox7.Items.Add(Convert.ToString(rd["id_stud"]));
                    comboBox6.Items.Add(Convert.ToString(rd["id_stud"]));
                }
                rd.Close();
                rd = com2.ExecuteReader();
                while (rd.Read())
                {
                    comboBox1.Items.Add(Convert.ToString(rd["id_stud"]));
                    comboBox2.Items.Add(Convert.ToString(rd["id_stud"]));
                }
                rd.Close();
                rd = com3.ExecuteReader();
                while (rd.Read())
                {
                    comboBox3.Items.Add(Convert.ToString(rd["name"]));
                    comboBox8.Items.Add(Convert.ToString(rd["name"]));
                }
                rd.Close();
                com12.Parameters.Clear(); com1.Parameters.Clear(); com2.Parameters.Clear(); com3.Parameters.Clear();
            }
        }

        private void adm_pers_Load(object sender, EventArgs e)
        {
            tabl.AllowUserToAddRows = false;    /////ЗАПРЩАЕМ ПОЛЬЗОВАТЕЛЯМ ДОБАВЛЯТЬ СТРОЧКИ КЛИКОМ НА ПОЛЕ
            tabl.AllowUserToDeleteRows = false; ////ЗАПРЩАЕМ ПОЛЬЗОВАТЕЛЯМ УДАЛЯТЬ СТРОЧКИ КЛИКОМ НА ПОЛЕtabl.Font.Size = 10;
            tabl.ReadOnly = true;               ////АКТИВИРУЕМ РЕЖИМ ТОЛЬКО ЧТЕНИЕ
           // tabl.Font.Size = 10;
            comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; ////////// ЗАПРЕТ РУЧНОГО ВВОДА В ВЫПАДАЮЩИЙ СПИСОК
            comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;////АКТИВИРУЕМ РЕЖИМ ТОЛЬКО ЧТЕНИЕ
            comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox7.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox8.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox9.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox10.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            // a_box4.Enabled = false; a_box4.Text = "0";
            //e_box4.Enabled = false;
            // ВЫВОД ТАБЛИЦЫ
  
                chl1();// button4.Enabled = false; button5.Enabled = false; button6.Enabled = false;
            
        }

        private void refresh_but_Click(object sender, EventArgs e)
        {

                chl1(); 
  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            b1c();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            b2c();
   
        }

        private void button3_Click(object sender, EventArgs e)
        {
            b3c();

        }
        
   
       void b1c()
        {
            string a, b, c, d, prov; int j = 0; prov = ""; int num; bool isNum1 = int.TryParse(textBox1.Text.Trim(), out num);
            a = Convert.ToString(comboBox7.SelectedItem);
            b = Convert.ToString(comboBox3.SelectedItem);
            //c = Convert.ToString(comboBox4.SelectedItem);
           // d = textBox1.Text;
            MySqlCommand com = new MySqlCommand("insert into progress(`id_stud`, `id_dis`) values (@a,@b)", Form1.MC);
            MySqlCommand com3 = new MySqlCommand("select id_dis from disciplines where name=@b", Form1.MC);
            MySqlCommand com2 = new MySqlCommand("select count(*) from progress where id_stud=@a and id_dis=@b", Form1.MC);
           
            

            if (Form1.MC.State == System.Data.ConnectionState.Closed)
                Form1.MC.Open();
            if (a.Length == 0 || b.Length == 0)
            {
                DialogResult ans = MessageBox.Show(
              "Поля не можуть бути порожніми! Необхідно заповнити усі поля",
              "Помилка",
               MessageBoxButtons.OK,
               MessageBoxIcon.Error,
               MessageBoxDefaultButton.Button1);
                return;
            }
            /*if (isNum1 == false)
            {
                DialogResult ans = MessageBox.Show(
                "Поле оцінка допускає тільки введення цифр! ",
                "Помилка",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Error,
                 MessageBoxDefaultButton.Button1);
                return;
            }
            if (comboBox4.SelectedItem.ToString() == "ПК1")
            {
                c = "PK1";
            }
            if (comboBox4.SelectedItem.ToString() == "ПК2")
            {
                c = "PK2";
            }
            if (comboBox4.SelectedItem.ToString() == "МК1")
            {
                c = "MK1";
            }
            if (comboBox4.SelectedItem.ToString() == "МК2")
            {
                c = "MK2";
            }
            if (comboBox4.SelectedItem.ToString() == "КП")
            {
                c = "kurs";
            }
            if (comboBox4.SelectedItem.ToString() == "ДП")
            {
                c = "dp";
            }*/
            
            com3.Parameters.AddWithValue("b", b);
            b = com3.ExecuteScalar().ToString();
            com2.Parameters.AddWithValue("b", b);
            com2.Parameters.AddWithValue("a", a);

            int cn = int.Parse(com2.ExecuteScalar().ToString());
            if(cn>0)
            {
                DialogResult ans = MessageBox.Show(
             "Запис про такого студента та дисципліну вже міститься у таблиці!",
             "Помилка",
              MessageBoxButtons.OK,
              MessageBoxIcon.Error,
              MessageBoxDefaultButton.Button1);
                return;
            }
           /* Regex_marks(textBox1, comboBox4.SelectedItem.ToString(), ref j);
            if (j == 1)
                return;*/
            com.Parameters.AddWithValue("a", a);
            com.Parameters.AddWithValue("b", b);
           // com.Parameters.AddWithValue("c", c);
           // com.Parameters.AddWithValue("d", d);
            com.ExecuteNonQuery();
            
            com.Parameters.Clear(); com2.Parameters.Clear(); com3.Parameters.Clear();
        }
       
        void b2c()
        {
            string a, b, c, d, f,g, prov; int j = 0; prov = ""; int num; bool isNum1 = int.TryParse(textBox2.Text.Trim(), out num);
            a = Convert.ToString(comboBox6.SelectedItem);
            b = Convert.ToString(comboBox8.SelectedItem);
            c = Convert.ToString(comboBox5.SelectedItem);
            d = textBox2.Text;
            f= Convert.ToString(comboBox1.SelectedItem);
            g = Convert.ToString(comboBox9.SelectedItem);

            MySqlCommand com = new MySqlCommand();
            MySqlCommand com3 = new MySqlCommand("select id_dis from disciplines where name=@g", Form1.MC);
            MySqlCommand com31 = new MySqlCommand("select id_dis from disciplines where name=@b", Form1.MC);
            MySqlCommand com2 = new MySqlCommand("select count(*) from progress where id_stud=@a and id_dis=@b", Form1.MC);
            if (Form1.MC.State == System.Data.ConnectionState.Closed)
                Form1.MC.Open();
            if (checkBox2.CheckState == CheckState.Checked)
            {
                if (c.Length == 0 || d.Length == 0 || f.Length == 0 || g.Length == 0)
                {
                    DialogResult ans = MessageBox.Show(
                  "Поля не можуть бути порожніми! Необхідно заповнити усі поля",
                  "Помилка",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error,
                   MessageBoxDefaultButton.Button1);
                    return;
                }
                com3.Parameters.AddWithValue("g", g);
                g = com3.ExecuteScalar().ToString();
            }
            else
            {
                 com = new MySqlCommand("update progress set id_stud=@a, id_dis=@b where id_stud=@f and id_dis=@g", Form1.MC);
                MySqlCommand comn = new MySqlCommand("select zalik from dis_groups where id_grp=@grp and id_dis=@b", Form1.MC);
                MySqlCommand como = new MySqlCommand("select ekzamen from dis_groups where id_grp=@grp and id_dis=@g", Form1.MC);
                MySqlCommand comg = new MySqlCommand("select id_grp from students where id_stud=@a", Form1.MC);
               
                if (a.Length == 0 || b.Length == 0 || f.Length == 0 || g.Length == 0)
                {
                    DialogResult ans = MessageBox.Show(
                  "Поля не можуть бути порожніми! Необхідно заповнити усі поля",
                  "Помилка",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error,
                   MessageBoxDefaultButton.Button1);
                    return;
                }
                com31.Parameters.AddWithValue("b", b);
                b = com31.ExecuteScalar().ToString();
                com3.Parameters.AddWithValue("g", g);
                g = com3.ExecuteScalar().ToString();
                com2.Parameters.AddWithValue("b", b);
                com2.Parameters.AddWithValue("a", a);
                comg.Parameters.AddWithValue("a", a);
                string grp = comg.ExecuteScalar().ToString();
                comn.Parameters.AddWithValue("b", b);
                comn.Parameters.AddWithValue("grp", grp);
                como.Parameters.AddWithValue("g", g);
                como.Parameters.AddWithValue("grp", grp);
                int zn = int.Parse(comn.ExecuteScalar().ToString());
                int ek = int.Parse(como.ExecuteScalar().ToString());
                if(zn==1 && ek==1)
                {
                    MySqlCommand commk = new MySqlCommand("update progress set MK1=0,MK2=0 where id_stud=@a and id_dis=@g", Form1.MC);
                    commk.Parameters.AddWithValue("g", g);
                    commk.Parameters.AddWithValue("a", a);
                    commk.ExecuteNonQuery(); commk.Parameters.Clear();
                }
               
                int cn = int.Parse(com2.ExecuteScalar().ToString());
                
                if (cn > 0)
                {
                    DialogResult ans = MessageBox.Show(
                 "Запис про такого студента та дисципліну вже міститься у таблиці!",
                 "Помилка",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Error,
                  MessageBoxDefaultButton.Button1);
                    return;
                }
                comn.Parameters.Clear();
                como.Parameters.Clear();
                comg.Parameters.Clear();
            }

            if (checkBox2.CheckState == CheckState.Checked)
            {
                if (isNum1 == false)
                {
                    DialogResult ans = MessageBox.Show(
                    "Поле оцінка допускає тільки введення цифр! ",
                    "Помилка",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Error,
                     MessageBoxDefaultButton.Button1);
                    return;
                }
                if (comboBox5.SelectedItem.ToString() == "ПК1")
                {
                    c = "PK1";
                }
                if (comboBox5.SelectedItem.ToString() == "ПК2")
                {
                    c = "PK2";
                }
                if (comboBox5.SelectedItem.ToString() == "МК1")
                {
                    c = "MK1";
                }
                if (comboBox5.SelectedItem.ToString() == "МК2")
                {
                    c = "MK2";
                }
                if (comboBox5.SelectedItem.ToString() == "КП")
                {
                    c = "kurs";
                }
                if (comboBox5.SelectedItem.ToString() == "ДП")
                {
                    c = "dp";
                }

                com = new MySqlCommand("update progress set " + c + "=@d where id_stud=@f and id_dis=@g", Form1.MC);
                Regex_marks(textBox2, comboBox5.SelectedItem.ToString(), ref j);
                if (j == 1)
                    return;
            }
            

            com.Parameters.AddWithValue("a", a);
            com.Parameters.AddWithValue("b", b);
           // com.Parameters.AddWithValue("c", c);
            com.Parameters.AddWithValue("d", d);
            com.Parameters.AddWithValue("f", f);
            com.Parameters.AddWithValue("g", g);


            
            com.ExecuteNonQuery(); 
            com.Parameters.Clear(); com2.Parameters.Clear(); com3.Parameters.Clear(); com31.Parameters.Clear();
        }
        
        void b3c()
        {
            string a,b;
            a = Convert.ToString(comboBox2.SelectedItem); MySqlCommand com;
            b = Convert.ToString(comboBox10.SelectedItem);
            if (Form1.MC.State == System.Data.ConnectionState.Closed)
                Form1.MC.Open();
            if (checkBox1.CheckState == CheckState.Unchecked)
            {
                com = new MySqlCommand("delete from progress where id_stud = @a and id_dis=@b", Form1.MC);
                MySqlCommand com1 = new MySqlCommand("select id_dis from disciplines where name=@b", Form1.MC);
                if (a.Length == 0 || b.Length == 0)
                {
                    DialogResult ans = MessageBox.Show(
                  "Поля не можуть бути порожніми! Необхідно заповнити усі поля",
                  "Помилка",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error,
                   MessageBoxDefaultButton.Button1);
                    return;
                }
                com1.Parameters.AddWithValue("b", b);
                b = com1.ExecuteScalar().ToString();
                com.Parameters.AddWithValue("a", a);
                com.Parameters.AddWithValue("b", b);
                com1.Parameters.Clear();
            }
            else
            {
                com = new MySqlCommand("delete from progress where id_stud = @a", Form1.MC);
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
                com.Parameters.AddWithValue("a", a);
            }

            com.ExecuteNonQuery();
            com.Parameters.Clear(); 
            
        }

       

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string a = Convert.ToString(comboBox1.SelectedItem);
            using (Form1.MC)
            {
                MySqlCommand com = new MySqlCommand("select distinct disciplines.name from disciplines,progress,dis_groups " +
                    "where disciplines.id_dis = progress.id_dis and disciplines.id_dis = dis_groups.id_dis  and progress.id_stud = @a and dis_groups.id_p = @idp", Form1.MC);
                com.Parameters.AddWithValue("a", a);
                com.Parameters.AddWithValue("idp", idp);
                // MySqlCommand com2 = new MySqlCommand("select distinct id_stud from progress", Form1.MC);
                if (Form1.MC.State == ConnectionState.Closed)
                    Form1.MC.Open();
                MySqlDataReader rd = com.ExecuteReader();
                comboBox9.Items.Clear();
                while (rd.Read())
                {
                    comboBox9.Items.Add(Convert.ToString(rd["name"]));
                }
                
                rd.Close(); com.Parameters.Clear(); 
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string a = Convert.ToString(comboBox2.SelectedItem);
            using (Form1.MC)
            {
                MySqlCommand com = new MySqlCommand("select distinct disciplines.name from disciplines,progress,dis_groups " +
                    "where disciplines.id_dis = progress.id_dis and disciplines.id_dis = dis_groups.id_dis  and progress.id_stud = @a and dis_groups.id_p = @idp", Form1.MC);
                com.Parameters.AddWithValue("a", a);
                com.Parameters.AddWithValue("idp", idp);
                // MySqlCommand com2 = new MySqlCommand("select distinct id_stud from progress", Form1.MC);
                if (Form1.MC.State == ConnectionState.Closed)
                    Form1.MC.Open();
                MySqlDataReader rd = com.ExecuteReader();
                comboBox10.Items.Clear();
                while (rd.Read())
                {
                    comboBox10.Items.Add(Convert.ToString(rd["name"]));
                }
                rd.Close(); com.Parameters.Clear();
            }
        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            if(checkBox1.CheckState==CheckState.Checked)
            {
                label17.Visible = false;
                comboBox10.SelectedItem = null;
                comboBox10.Visible = false;
            }
            else
            {
                label17.Visible = true;
                comboBox10.Visible = true;
            }
        }
        
        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedItem == null)
                return;
            if(comboBox7.SelectedItem==null)
            {
                comboBox3.SelectedItem = null;
                DialogResult ans = MessageBox.Show(
                 "Спочатку оберіть номер студента!",
                 "Увага",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Warning,
                  MessageBoxDefaultButton.Button1);
                return;
            }
            string grp; string a = Convert.ToString(comboBox7.SelectedItem); string b = Convert.ToString(comboBox3.SelectedItem); int z=0, ek=0;
            MySqlCommand com1 = new MySqlCommand("select id_grp from students where id_stud=@a", Form1.MC);
            MySqlCommand com2 = new MySqlCommand("select zalik from dis_groups where id_grp=@grp and id_dis=@b", Form1.MC);
            MySqlCommand com2c1 = new MySqlCommand("select count(*) from dis_groups where id_grp=@grp and id_dis=@b and zalik=1", Form1.MC);
            MySqlCommand com2c2 = new MySqlCommand("select count(*) from dis_groups where id_grp=@grp and id_dis=@b and ekzamen=1", Form1.MC);
            MySqlCommand com21 = new MySqlCommand("select ekzamen from dis_groups where id_grp=@grp and id_dis=@b", Form1.MC);
            MySqlCommand com3 = new MySqlCommand("select id_dis from disciplines where name=@b", Form1.MC);
            using (Form1.MC)
            {
                if (Form1.MC.State == ConnectionState.Closed)
                    Form1.MC.Open();
                com1.Parameters.AddWithValue("a", a);
                com3.Parameters.AddWithValue("b", b);
                grp = com1.ExecuteScalar().ToString();
                b = com3.ExecuteScalar().ToString();
                com2.Parameters.AddWithValue("grp", grp);
                com2.Parameters.AddWithValue("b", b);
                com21.Parameters.AddWithValue("grp", grp);
                com21.Parameters.AddWithValue("b", b);
                com2c1.Parameters.AddWithValue("grp", grp);
                com2c1.Parameters.AddWithValue("b", b);
                com2c2.Parameters.AddWithValue("grp", grp);
                com2c2.Parameters.AddWithValue("b", b);

                int c1 = int.Parse(com2c1.ExecuteScalar().ToString());
                int c2 = int.Parse(com2c2.ExecuteScalar().ToString());

                if ( c1 !=1 &&  c2 != 1)
                {
                    comboBox3.SelectedItem = null;
                    DialogResult ans = MessageBox.Show(
                                     "Не вдається знайти запис про контрольні терміни відносно групи  обраного студента і дисципліни!\nЯкщо потрібно додати запис про таку групу і дисципліну - зверніться до адміністратора.",
                                     "Увага",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Warning,
                                      MessageBoxDefaultButton.Button1);
                    return;
                }
                if(c1 == 1)
                    z = int.Parse(com2.ExecuteScalar().ToString());
                if (c2 == 1)
                    ek = int.Parse(com21.ExecuteScalar().ToString());
                if (z == 1)
                {
                    comboBox4.Items.Clear();
                    comboBox4.Items.Add("ПК1");
                    comboBox4.Items.Add("ПК2");
                }
                if(ek==1)
                {
                    comboBox4.Items.Clear();
                    comboBox4.Items.Add("ПК1");
                    comboBox4.Items.Add("МК1");
                    comboBox4.Items.Add("ПК2");
                    comboBox4.Items.Add("МК2");
                    comboBox4.Items.Add("КП");
                    comboBox4.Items.Add("ДП");
                }

            }
            com1.Parameters.Clear(); com2.Parameters.Clear(); com3.Parameters.Clear(); com21.Parameters.Clear();
            com2c1.Parameters.Clear(); com2c2.Parameters.Clear(); 
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox9.SelectedItem == null)
                return;
            if (comboBox1.SelectedItem == null )
            {
                comboBox9.SelectedItem = null;
                DialogResult ans = MessageBox.Show(
                 "Спочатку оберіть номер студента!",
                 "Увага",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Warning,
                  MessageBoxDefaultButton.Button1);
                return;
            }
            string grp; string a = Convert.ToString(comboBox1.SelectedItem); string g = Convert.ToString(comboBox9.SelectedItem); int z = 0, ek = 0;
            MySqlCommand com1 = new MySqlCommand("select id_grp from students where id_stud=@a", Form1.MC);
            MySqlCommand com3 = new MySqlCommand("select id_dis from disciplines where name=@g", Form1.MC);
            MySqlCommand com21 = new MySqlCommand("select ekzamen from dis_groups where id_grp=@grp and id_dis=@g", Form1.MC);
            MySqlCommand com2 = new MySqlCommand("select zalik from dis_groups where id_grp=@grp and id_dis=@g", Form1.MC);
            MySqlCommand com2c1 = new MySqlCommand("select count(*) from dis_groups where id_grp=@grp and id_dis=@g and zalik=1", Form1.MC);
            MySqlCommand com2c2 = new MySqlCommand("select count(*) from dis_groups where id_grp=@grp and id_dis=@g and ekzamen=1", Form1.MC);
            using (Form1.MC)
            {
                if (Form1.MC.State == ConnectionState.Closed)
                    Form1.MC.Open();
                com1.Parameters.AddWithValue("a", a);
                com3.Parameters.AddWithValue("g", g);
                grp = com1.ExecuteScalar().ToString();
                //MessageBox.Show(g);
                g = com3.ExecuteScalar().ToString();
                com2.Parameters.AddWithValue("grp", grp);
                com2.Parameters.AddWithValue("g", g);
                com21.Parameters.AddWithValue("grp", grp);
                com21.Parameters.AddWithValue("g", g);
                com2c1.Parameters.AddWithValue("grp", grp);
                com2c1.Parameters.AddWithValue("g", g);
                com2c2.Parameters.AddWithValue("grp", grp);
                com2c2.Parameters.AddWithValue("g", g);

                int c1 = int.Parse(com2c1.ExecuteScalar().ToString());
                int c2 = int.Parse(com2c2.ExecuteScalar().ToString());
                 //MessageBox.Show("z: "+c1.ToString());
               // MessageBox.Show("e: "+c2.ToString());
                if (c1 != 1 && c2 != 1)
                {
                    comboBox8.SelectedItem = null;
                    DialogResult ans = MessageBox.Show(
                                     "Не вдається знайти запис про контрольні терміни відносно групи  обраного студента і дисципліни!\nЯкщо потрібно додати запис про таку групу і дисципліну - зверніться до адміністратора.",
                                     "Увага",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Warning,
                                      MessageBoxDefaultButton.Button1);
                    return;
                }
                if (c1 == 1)
                    z = int.Parse(com2.ExecuteScalar().ToString());
                if (c2 == 1)
                    ek = int.Parse(com21.ExecuteScalar().ToString());

               // MessageBox.Show(z.ToString());
               // MessageBox.Show(ek.ToString());
                if (z == 1)
                {
                    comboBox5.Items.Clear();
                    comboBox5.Items.Add("ПК1");
                    comboBox5.Items.Add("ПК2");
                }
                if (ek == 1)
                {
                    comboBox5.Items.Clear();
                    comboBox5.Items.Add("ПК1");
                    comboBox5.Items.Add("МК1");
                    comboBox5.Items.Add("ПК2");
                    comboBox5.Items.Add("МК2");
                    comboBox5.Items.Add("КП");
                    comboBox5.Items.Add("ДП");
                }

            }
            com1.Parameters.Clear(); com2.Parameters.Clear(); com3.Parameters.Clear(); com21.Parameters.Clear();
            com2c1.Parameters.Clear(); com2c2.Parameters.Clear();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e) // СМЕНА ПОЛОЖЕНИЯ НАДПИСЕЙ И БОКСОВ ПО ФЛАГУ
        {
            Point l10 = label10.Location;
            Point l3 = label3.Location;
            Point c5 = comboBox5.Location;
            Point t2 = textBox2.Location;
            if (checkBox2.CheckState == CheckState.Checked)
            {
                label10.Visible = true;
                label3.Visible = true;
                comboBox5.Visible = true;
                textBox2.Visible = true;
                
                label10.Location = label13.Location;
                label3.Location = label12.Location; 
                comboBox5.Location = new Point(comboBox6.Location.X+10,comboBox6.Location.Y );
                textBox2.Location = new Point(comboBox8.Location.X - 10, comboBox8.Location.Y);

                label12.Visible = false;
                label13.Visible = false;
                comboBox6.Visible = false;
                comboBox8.Visible = false;
            }
            else
            {
                label10.Visible = false;
                label3.Visible = false;
                comboBox5.Visible = false;
                textBox2.Visible = false;

                label10.Location = l10;
                label3.Location = l3;
                comboBox5.Location = c5;
                textBox2.Location = t2;

                label12.Visible = true;
                label13.Visible = true;
                comboBox6.Visible = true;
                comboBox8.Visible = true;
            }
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox8.SelectedItem == null)
                return;
            if (comboBox6.SelectedItem == null)
            {
                comboBox8.SelectedItem = null;
                DialogResult ans = MessageBox.Show(
                 "Спочатку оберіть номер студента!",
                 "Увага",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Warning,
                  MessageBoxDefaultButton.Button1);
                return;
            }
            string grp; string a = Convert.ToString(comboBox6.SelectedItem); string b = Convert.ToString(comboBox8.SelectedItem);
            MySqlCommand com1 = new MySqlCommand("select id_grp from students where id_stud=@a", Form1.MC);
            MySqlCommand com3 = new MySqlCommand("select id_dis from disciplines where name=@b", Form1.MC);
            MySqlCommand com2c1 = new MySqlCommand("select count(*) from dis_groups where id_grp=@grp and id_dis=@b and zalik=1", Form1.MC);
            MySqlCommand com2c2 = new MySqlCommand("select count(*) from dis_groups where id_grp=@grp and id_dis=@b and ekzamen=1", Form1.MC);
            using (Form1.MC)
            {   
                if (Form1.MC.State == ConnectionState.Closed)
                    Form1.MC.Open();
                com1.Parameters.AddWithValue("a", a);
                com3.Parameters.AddWithValue("b", b);
                grp = com1.ExecuteScalar().ToString();
                b = com3.ExecuteScalar().ToString();
                com2c1.Parameters.AddWithValue("grp", grp);
                com2c1.Parameters.AddWithValue("b", b);
                com2c2.Parameters.AddWithValue("grp", grp);
                com2c2.Parameters.AddWithValue("b", b);
                int c1 = int.Parse(com2c1.ExecuteScalar().ToString());
                int c2 = int.Parse(com2c2.ExecuteScalar().ToString());

                if (c1 != 1 && c2 != 1)
                {
                    comboBox8.SelectedItem = null;
                    DialogResult ans = MessageBox.Show(
                                     "Не вдається знайти запис про контрольні терміни відносно групи  обраного студента і дисципліни!\nЯкщо потрібно додати запис про таку групу і дисципліну - зверніться до адміністратора.",
                                     "Увага",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Warning,
                                      MessageBoxDefaultButton.Button1);
                    return;
                }

            }
            com2c1.Parameters.Clear(); com2c2.Parameters.Clear(); com1.Parameters.Clear(); com3.Parameters.Clear();
        }
    }
}
