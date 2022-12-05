using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace turism
{
    public partial class staff : Form
    {

        public staff()

        {
            InitializeComponent();
            getInfo();
        }
        private void getInfo()
        {
            string query = ("SELECT id_staff as'№', fio as'ФИО', post as'Должность', phone'Телефон', adress as'Адрес', wages as'Зарплата($)' from staff;");
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlDataAdapter ada = new MySqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                ada.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string add = ("insert into staff(fio, post, phone, adress, wages) values('" + textBox1.Text + "', '" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "');");
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand cmDB = new MySqlCommand(add, conn);

            try
            {
                conn.Open();
                MySqlDataReader rd = cmDB.ExecuteReader();
                conn.Close();
                MessageBox.Show("Данные внесены!");
                getInfo();
            }
            catch (Exception)
            {
                MessageBox.Show("Заполните все поля!");
            }

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

       

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
                textBox1.Text = dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString();
                textBox2.Text = dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString();
                textBox3.Text = dataGridView1[3, dataGridView1.CurrentRow.Index].Value.ToString();
                textBox4.Text = dataGridView1[4, dataGridView1.CurrentRow.Index].Value.ToString();
                textBox5.Text = dataGridView1[5, dataGridView1.CurrentRow.Index].Value.ToString();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string update = "update staff set fio = '" + textBox1.Text + "',post = '" + textBox2.Text + "', phone = '" + textBox3.Text + "', adress = '" + textBox4.Text + "', wages = " + textBox5.Text + " where id_staff = " + dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString() + ";";
            MySqlConnection conn = DBUtils.GetDBConnection(); 
            MySqlCommand cmDB = new MySqlCommand(update, conn);
            try
            {
                conn.Open();
                cmDB.ExecuteReader();
                conn.Close();
                MessageBox.Show("Данные обновлены!");
                getInfo();
            }
            catch (Exception)
            {
                MessageBox.Show("Возникла непредвиденная ошибка.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Вы уверены, что хотите удалить данные?", "БЕЗВОЗВРАТНОЕ УДАЛЕНИЕ!!!", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                string del = "delete from staff where id_staff = " + dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString() + ";";
                MySqlConnection conn = DBUtils.GetDBConnection();
                MySqlCommand cmDB = new MySqlCommand(del, conn);
                try
                {
                    conn.Open();
                    cmDB.ExecuteReader();
                    conn.Close();
                    MessageBox.Show("Данные удалены!");
                    getInfo();
                }
                catch (Exception)
                {
                    MessageBox.Show("Возникла непредвиденная ошибка.");
                }
            }
        }
    }
}
