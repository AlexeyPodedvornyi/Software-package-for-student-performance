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
    public partial class Form1 : Form
    {
        public static string connect;
        public static string connect2;
        public Form1()
        {
            InitializeComponent();
            pfield.AutoSize = false;
            pfield.Size = new Size(pfield.Size.Width, 41);
            lfield.ForeColor = Color.Gray;
            pfield.ForeColor = Color.Gray;
            lfield.Text = "Введіть логін";
            pfield.Text = "Введіть пароль";
            

        }
       
        public static MySqlConnection MC=null;  public static string lvl,p, pos; public static MySqlConnection MC2 = null;


        private void button2_Click(object sender, EventArgs e)
        {
            string login_u = lfield.Text;
            string pass_u = pfield.Text;
            string adress= Convert.ToString(comboBox1.SelectedItem);
            

            connect = "server="+adress+";port=3306;username="+login_u+";password="+pass_u+";database=practice;Allow User Variables=True;convert zero datetime=true"; 
           // connect2 = "server="+adress+";port=3306;username=" + login_u + ";password=" + pass_u + ";database=kurs;Allow User Variables=True;convert zero datetime=true";

            MC = new MySqlConnection(connect);
            //MC2 = new MySqlConnection(connect2);
       
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            //MessageBox.Show(login_u, pass_u);

            const string CmdText = "select * from logins WHERE login = @l AND pass = @p";
            MySqlCommand comid = new MySqlCommand("select id_p from logins where login = @l", MC); // nom prepoda
           // MySqlCommand compos = new MySqlCommand("select pos from staff where id_p = @p", MC);
           // MySqlCommand com0 = new MySqlCommand("select ac_lvl from posit where id_pos = @pos", MC);
           // MySqlCommand com1 = new MySqlCommand("select login from logim where login = @l", MC);
            MySqlCommand command = new MySqlCommand(CmdText, MC);//Соединяемся с БД и выполняем команду
            //pos = "", p = ""; 

            command.Parameters.Add("@l", MySqlDbType.VarChar).Value = login_u;//Присваиваем заглушке введенный логин
            command.Parameters.Add("@p", MySqlDbType.VarChar).Value = pass_u;//Присваиваем заглушке введенный пароль
            //com0.Parameters.Add("@l", MySqlDbType.VarChar).Value = login_u;
            //com1.Parameters.Add("@l", MySqlDbType.VarChar).Value = login_u;
            adapter.SelectCommand = command;//Выбираем команду для выполнения адаптером
            try
            { adapter.Fill(table); }//Заполняем таблицу table получеными данными 
            catch (MySqlException)
            {
                DialogResult ans = MessageBox.Show("Помилка під час отримання запиту від сервера!\nЗверніться до адміністратора або перевірте коректність даних авторизації", "\nПомилка ",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Stop,
                     MessageBoxDefaultButton.Button1
                      );
                return;
            }
            try
            {
                if (MC.State == ConnectionState.Closed)
                    MC.Open();
            }
            catch (MySqlException)
            {
                DialogResult ans=  MessageBox.Show("Неможливо встановити зв'язок с сервером. Сервер MySQL не відповідає!\nЗверніться до адміністратора", "\nПомилка ",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Warning,
                     MessageBoxDefaultButton.Button1
                      );
                return;
            }
            if (table.Rows.Count > 0)
            {
                comid.Parameters.AddWithValue("l", login_u);
                p = comid.ExecuteScalar().ToString();
               // compos.Parameters.AddWithValue("p", p);
               /* if (login_u != "admin")
                {
                    pos = compos.ExecuteScalar().ToString();
                    com0.Parameters.AddWithValue("pos", pos);
                    lvl = com0.ExecuteScalar().ToString();
                }*/
                string login = login_u;
                //login = com1.ExecuteScalar().ToString();
                //current_login = login;
                DialogResult ans = MessageBox.Show("Ви успішно увійшли до системи.", "\nЛаскаво просимо! ",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Information,
                     MessageBoxDefaultButton.Button1
                      );
                MC.Close();
                this.Hide();

                Menu main = new Menu(ref lvl, ref login); //
                main.Show();

            }
            else
            {
                DialogResult ans = MessageBox.Show("Помилка авторизації.", " \nПеревірьте правильність введених даних!",
                    MessageBoxButtons.OK,
                     MessageBoxIcon.Error,
                     MessageBoxDefaultButton.Button1
                      );
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            if(MC!=null )
            {
                if(MC.State ==ConnectionState.Open )
                {
                    MC.Close();//MC2.Close();
                }
                MC.Dispose();//MC2.Dispose();
            }
            Application.Exit();
        }

        private void lfield_Enter(object sender, EventArgs e)
        {
            if (lfield.Text == "Введіть логін")
            {
                lfield.ForeColor = Color.Black ;
                lfield.Text = "";
            }

        }

        private void lfield_Leave(object sender, EventArgs e)
        {
            if (lfield.Text == "")
            {
                lfield.ForeColor = Color.Gray;
                lfield.Text = "Введіть логін";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        private void pfield_Enter(object sender, EventArgs e)
        {
            if (pfield.Text == "Введіть пароль")
            {
                pfield.ForeColor = Color.Black;
                pfield.Text = "";
            }
        }

        private void pfield_Leave(object sender, EventArgs e)
        {
            if (pfield.Text == "")
            {
                pfield.ForeColor = Color.Gray;
                pfield.Text = "Введіть пароль";
            }
        }
    }
        
}



