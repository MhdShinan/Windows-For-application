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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            this.Hide();
            f3.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=ATTACKER\SQLEXPRESS;Initial Catalog=Madzoodigital;Integrated Security=True"))
            {
                connection.Open();
                string query = "Insert into player values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "')";
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Data added to database");

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=ATTACKER\SQLEXPRESS;Initial Catalog=Madzoodigital;Integrated Security=True"))
            {
                connection.Open();

                string query = "DELETE FROM Player WHERE PlayerID = @PlayerID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@PlayerID", textBox1.Text);

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

        private void button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=ATTACKER\SQLEXPRESS;Initial Catalog=Madzoodigital;Integrated Security=True"))
            {
                connection.Open();

                // Declare the scalar variable
                SqlParameter parameter = new SqlParameter("@playerID", SqlDbType.Int);

                string query = "SELECT * FROM player WHERE playerID = @playerID";
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

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=ATTACKER\SQLEXPRESS;Initial Catalog=Madzoodigital;Integrated Security=True");
            string query = "update player set firstName = '" + textBox2.Text + "' ,lastName = '" + textBox3.Text + "',Dateofbirth = '" + textBox4.Text + "',Shirtnumber = '" + textBox5.Text + "',Startyear = '" + textBox6.Text + "' where Playerid = '" + comboBox1.Text + "'";
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
    }
}
