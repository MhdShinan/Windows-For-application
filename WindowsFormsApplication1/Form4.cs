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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

     
      
        private void button5_Click_1(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            this.Hide();
            f5.Show();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            this.Hide();
            f3.Show();

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=ATTACKER\SQLEXPRESS;Initial Catalog=Madzoodigital;Integrated Security=True"))
            {
                connection.Open();
                string query = "Insert into match values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "')";
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Data added to database");

            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=ATTACKER\SQLEXPRESS;Initial Catalog=Madzoodigital;Integrated Security=True"))
            {
                connection.Open();

                string query = "DELETE FROM PlayerMatch WHERE PlayerMatchID = @PlayerMatchID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@PlayerMatchID ", textBox1.Text);

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

        private void button3_Click_1(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=ATTACKER\SQLEXPRESS;Initial Catalog=Madzoodigital;Integrated Security=True"))
            {
                connection.Open();

                // Declare the scalar variable
                SqlParameter parameter = new SqlParameter("@PlayerMatchID", SqlDbType.Int);

                string query = "SELECT * FROM PlayerMatch WHERE PlayerMatchID = @PlayerMatchID";
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

        private void button2_Click_1(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=ATTACKER\SQLEXPRESS;Initial Catalog=Madzoodigital;Integrated Security=True");
            string query = "update playermatch set SubstitutedPlayerID  = '" + textBox3.Text + "' ,SubstitutionTime = '" + textBox4.Text + "',GoalsScored = '" + textBox5.Text + "',YellowCard = '" + textBox6.Text + "',RedCard  = '" + textBox7.Text + "' where PlayerMatchid = '" + comboBox1.Text + "'";
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
