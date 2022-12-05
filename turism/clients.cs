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

namespace turism
{
    public partial class clients : Form
    {
        public int ID_char = 0;
        public clients()
        {
            InitializeComponent();
            getInfo();
           
        }

        private void getInfo()
        {
            string query = ("SELECT id_client as'№', fio as'ФИО', phone as'Телефон', adress as'Адрес' from clients;");
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
        public void getBoxes(string query, ComboBox box)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand cmDB = new MySqlCommand(query, conn);
            try
            {
                conn.Open();
                MySqlDataReader rd = cmDB.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        box.Items.Add(rd.GetString(0));
                    }
                }
                conn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Произошла непредвиденная ошибка загрузки классов или рас!" + Environment.NewLine + ex.Message);
            }
        }

        private void Add_Click_1(object sender, EventArgs e)
        {
            string add = ("insert into clients(fio, phone, adress) values('" + textBox1.Text + "', '" + textBox2.Text + "','" + textBox3.Text + "');");
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand cmDB = new MySqlCommand(add, conn);
            try
            {
                conn.Open();
                MySqlDataReader rd = cmDB.ExecuteReader();
                conn.Close();
                MessageBox.Show("Данные внесены!");
            }
            catch (Exception)
            {
                MessageBox.Show("Заполните все поля!");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
    
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox1.Text = dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString();
            textBox2.Text = dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString();
            textBox3.Text = dataGridView1[3, dataGridView1.CurrentRow.Index].Value.ToString();
         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string update = "update clients set fio = '" + textBox1.Text + "', phone = '" + textBox2.Text + "', adress = '" + textBox3.Text + "' where id_client = " + dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString() + ";";
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

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Вы уверены, что хотите удалить данные?", "БЕЗВОЗВРАТНОЕ УДАЛЕНИЕ!!!", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                string del = "delete from clients where id_client = " + dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString() + ";";
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
