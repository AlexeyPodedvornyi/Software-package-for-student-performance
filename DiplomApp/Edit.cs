using MySql.Data.MySqlClient;
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
    public partial class Edit : Form
    {
       public int m; public string name; public string id; public string chb; public string state;
        public Edit()
        {
            //m = max;
            InitializeComponent();
        }
        public int state1; MySqlConnection MC;
        
        private void button1_Click(object sender, EventArgs e)
        {
            int num; bool isNum3 = int.TryParse(textBox1.Text.Trim(), out num);
            if (isNum3 == false)
            {
                DialogResult ans = MessageBox.Show(
                "Поле вводу може містити тільки цілі числа \nСпробуйте ще раз",
                "Помилка",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Error,
                 MessageBoxDefaultButton.Button1);
                return;
            }
            if (int.Parse(textBox1.Text)>m || int.Parse(textBox1.Text)<0)
            {
                DialogResult ans = MessageBox.Show(
               "Помилкове значення поля вводу \nСпробуйте ще раз",
               "Помилка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1);
                return;
            }
            if (state1 == 1)
            {
                MC = Form1.MC2;
            }
            else
                MC = Form1.MC;
            if (MC.State ==ConnectionState.Closed)
            MC.Open();
            if (name == "Вступ")
            {
                MySqlCommand com = new MySqlCommand("update cont_parts set vstup = @a where id_stud=@id", MC);
                com.Parameters.AddWithValue("a", textBox1.Text);
                com.Parameters.AddWithValue("id", id);
                com.ExecuteNonQuery(); com.Parameters.Clear(); //label3.Text = label3.Text + m.ToString();
            }
            if (name == "Загальна частина")
            {
                MySqlCommand com = new MySqlCommand("update cont_parts set zag_ch = @a where id_stud=@id", MC);
                com.Parameters.AddWithValue("a", textBox1.Text);
                com.Parameters.AddWithValue("id", id);
                com.ExecuteNonQuery(); com.Parameters.Clear(); //label3.Text = label3.Text + m.ToString();
            }
            if (name == "Спеціальна частина")
            {
                MySqlCommand com = new MySqlCommand("update cont_parts set spec_ch = @a where id_stud=@id", MC);
                com.Parameters.AddWithValue("a", textBox1.Text);
                com.Parameters.AddWithValue("id", id); com.ExecuteNonQuery(); com.Parameters.Clear(); //label3.Text = label3.Text + m.ToString();
            }
            if (name == "Експлуатаційна частина")  ///
            {   
                MySqlCommand com = new MySqlCommand("update cont_parts set ekspl_ch = @a where id_stud=@id", MC);
                com.Parameters.AddWithValue("a", textBox1.Text);
                com.Parameters.AddWithValue("id", id); com.ExecuteNonQuery();
                if(state=="Checked")
                {
                    MySqlCommand com1 = new MySqlCommand("update cont_parts set techn_ch = 0 where id_stud=@id", MC);
                    com1.Parameters.AddWithValue("id", id);
                    com1.ExecuteNonQuery(); com1.Parameters.Clear();
                }
                else
                {
                    MySqlCommand com1 = new MySqlCommand("update cont_parts set techn_ch = 10 where id_stud=@id", MC);
                    MySqlCommand com2 = new MySqlCommand("select techn_ch from cont_parts where id_stud=@id", MC);
                    com1.Parameters.AddWithValue("id", id);
                    com2.Parameters.AddWithValue("id", id);
                    int c1 = com2.ExecuteNonQuery();
                    if(c1>10)
                        com1.ExecuteNonQuery();
                    
                    com1.Parameters.Clear(); com2.Parameters.Clear();

                }
                com.Parameters.Clear(); //label3.Text = label3.Text + m.ToString();
            }
            if (name == "Технологічна частина") ///
            {
                MySqlCommand com = new MySqlCommand("update cont_parts set techn_ch = @a where id_stud=@id", MC);
                com.Parameters.AddWithValue("a", textBox1.Text);
                com.Parameters.AddWithValue("id", id); com.ExecuteNonQuery(); com.Parameters.Clear(); //label3.Text = label3.Text + m.ToString();
            }
            if (name == "Економічна частина")
            {
                MySqlCommand com = new MySqlCommand("update cont_parts set econom_ch = @a where id_stud=@id", MC);
                com.Parameters.AddWithValue("a", textBox1.Text);
                com.Parameters.AddWithValue("id", id); com.ExecuteNonQuery(); com.Parameters.Clear();// label3.Text = label3.Text + m.ToString();
            }
            if (name == "ОП")
            {
                MySqlCommand com = new MySqlCommand("update cont_parts set op = @a where id_stud=@id", MC);
                com.Parameters.AddWithValue("a", textBox1.Text);
                com.Parameters.AddWithValue("id", id); com.ExecuteNonQuery(); com.Parameters.Clear(); //label3.Text = label3.Text + m.ToString();
            }
            if (name == "Графічна частина 1")
            {
                MySqlCommand com = new MySqlCommand("update cont_parts set graph_ch1 = @a where id_stud=@id", MC);
                com.Parameters.AddWithValue("a", textBox1.Text);
                com.Parameters.AddWithValue("id", id); com.ExecuteNonQuery(); com.Parameters.Clear();// label3.Text = label3.Text + m.ToString();
            }
            if (name == "Графічна частина 2")
            {
                MySqlCommand com = new MySqlCommand("update cont_parts set graph_ch2 = @a where id_stud=@id", MC);
                com.Parameters.AddWithValue("a", textBox1.Text);
                com.Parameters.AddWithValue("id", id); com.ExecuteNonQuery(); com.Parameters.Clear(); //label3.Text = label3.Text + m.ToString();
            }
            if (name == "Висновок")
            {
                MySqlCommand com = new MySqlCommand("update cont_parts set visnovok = @a where id_stud=@id", MC);
                com.Parameters.AddWithValue("a", textBox1.Text);
                com.Parameters.AddWithValue("id", id); com.ExecuteNonQuery();com.Parameters.Clear(); //label3.Text = label3.Text + m.ToString();
            }
            DialogResult ans1 = MessageBox.Show(
             "Дані були успішно занесені",
             "Операція успішна!",
              MessageBoxButtons.OK,
              MessageBoxIcon.Information,
              MessageBoxDefaultButton.Button1);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult ans = MessageBox.Show(
             "Після внесення змін, для їх коректного відображення необхідну клацнути на кнопку із значком 'Оновити'.\nІнакше внесені зміни не будуть відображені!",
             "Зверніть увагу!",
              MessageBoxButtons.OK,
              MessageBoxIcon.Warning,
              MessageBoxDefaultButton.Button1);
            this.Close();
        }

        private void Edit_Load(object sender, EventArgs e)
        {
             label3.Text = label3.Text + " "+m;
            //MessageBox.Show(chb);
            /*if (chb == "Checked")
            {
                
                label1.Text = "Для цього пункту рекомендується виставляти\nзначення кратні 2-ум!";

                label1.ForeColor = Color.Red;
            }
            else
                label1.Visible = false;*/
            
        }
    }
}
