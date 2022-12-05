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
    public partial class deal : Form
    {
        public deal()
        {
            InitializeComponent();
            getInfo();
        }

        public void getInfo()
        {
            string query = ("SELECT id_deal as'№ Путёвки',  id_client as'№ Клиента',  id_tour as'№ Тура',  start_date as'Начало тура',  end_date as'Конец тура', price_tour as'Стоимость тура', date_pay as'Оплата', id_staff as'№ Сотрудника' from deal;");
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

        private void button1_Click(object sender, EventArgs e)
        {
            string add = ("insert into deal(id_client, id_tour, start_date, end_date, price_tour, date_pay, id_staff ) values('" + textBox1.Text + "', '" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "');");
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

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox1.Text = dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString();
            textBox2.Text = dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString();
            textBox3.Text = dataGridView1[3, dataGridView1.CurrentRow.Index].Value.ToString();
            textBox4.Text = dataGridView1[4, dataGridView1.CurrentRow.Index].Value.ToString();
            textBox5.Text = dataGridView1[5, dataGridView1.CurrentRow.Index].Value.ToString();
            textBox6.Text = dataGridView1[6, dataGridView1.CurrentRow.Index].Value.ToString();
            textBox7.Text = dataGridView1[7, dataGridView1.CurrentRow.Index].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string update = "update deal set id_client = '" + textBox1.Text + "', id_tour = '" + textBox2.Text + "', start_date = '" + textBox3.Text + "', end_date = '" + textBox4.Text + "', price_tour = " + textBox5.Text + ",  date_pay = '" + textBox6.Text + "', id_staff = '" + textBox7.Text + "' where id_deal = " + dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString() + ";";
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
                string del = "delete from deal where id_deal = " + dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString() + ";";
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
