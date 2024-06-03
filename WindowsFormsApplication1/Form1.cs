using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
             using (SqlConnection connection = new SqlConnection(@"Data Source=ATTACKER\SQLEXPRESS;Initial Catalog=Madzoodigital;Integrated Security=True"))
            {
                                    connection.Open();
                                    string query = "Insert into team values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Data added to database");               
                           
               }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            this.Hide();
            f2.Show();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
                    {
            SqlConnection connection = new SqlConnection(@"Data Source=ATTACKER\SQLEXPRESS;Initial Catalog=Madzoodigital;Integrated Security=True");
            string query = "update Team set firstName = '" + textBox2.Text + "' ,lastName = '" + textBox3.Text + "',Mainstadium = '" + textBox4.Text + "',city = '" + textBox5.Text + "' where Teamid = '" + comboBox1.Text + "'";
            SqlCommand com = new SqlCommand(query, connection);
                        try
            {
                connection.Open();
                com.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("update success");
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=ATTACKER\SQLEXPRESS;Initial Catalog=Madzoodigital;Integrated Security=True"))
            {
                connection.Open();

                // Declare the scalar variable
                SqlParameter parameter = new SqlParameter("@TeamID", SqlDbType.Int);

                string query = "SELECT * FROM Team WHERE TeamID = @TeamID";
                SqlCommand command = new SqlCommand(query, connection);

                // Get the value ID from the user
                string id = textBox1.Text;

                // Bind the value ID to the parameter
                parameter.Value = Convert.ToInt32(id);
                command.Parameters.Add(parameter);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
                connection.Close();
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=ATTACKER\SQLEXPRESS;Initial Catalog=Madzoodigital;Integrated Security=True"))
            {
                connection.Open();

                string query = "DELETE FROM Team WHERE TeamID = @TeamID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@TeamID", textBox1.Text);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Data deleted from the database");
                    }
                    else
                    {
                        MessageBox.Show("No matching records found.");
                    }
                }

                connection.Close();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
