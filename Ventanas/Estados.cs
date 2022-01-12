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

namespace ProyectoBD.Ventanas
{
    public partial class Estados : Form
    {
        SqlDataAdapter adap;
        DataTable dt;
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-JRQ86QG;Initial Catalog=BIBLIOTECA;Integrated Security=True;");
        SqlCommand cmd;

        public Estados()
        {
            InitializeComponent();
            mostrarDatos();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("select * from vista2", con);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
            textBox1.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GC.Collect();
            this.Dispose();
        }

        private void Estados_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'bIBLIOTECADataSet.vista2' Puede moverla o quitarla según sea necesario.
            this.vista2TableAdapter.Fill(this.bIBLIOTECADataSet.vista2);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == String.Empty)
            {
                MessageBox.Show("Llene los datos correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (comboBox1.Text == "IdLibro")
                {
                    con.Open();
                    cmd = new SqlCommand("select * from vista2 where [Id Libro] like '" + textBox1.Text + "'", con);
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    MessageBox.Show("Datos encontrados");
                    con.Close();
                    textBox1.Clear();

                }
                else if (comboBox1.Text == "No. Cliente")
                {
                    con.Open();
                    cmd = new SqlCommand("select * from vista2 where [No. Cliente] like '" + textBox1.Text + "'", con);
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    MessageBox.Show("Datos encontrados");
                    con.Close();
                    textBox1.Clear();
                }
                else if (comboBox1.Text == "Nombre Cliente")
                {
                    con.Open();
                    cmd = new SqlCommand("select * from vista2 where Nombre like '%" + textBox1.Text + "%'", con);
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    MessageBox.Show("Datos encontrados");
                    con.Close();
                    textBox1.Clear();

                }
                else if (comboBox1.Text == "Titulo")
                {
                    con.Open();
                    cmd = new SqlCommand("select * from vista2 where Titulo like '%" + textBox1.Text + "%'", con);
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    MessageBox.Show("Datos encontrados");
                    con.Close();
                    textBox1.Clear();
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public void mostrarDatos() 
        {
            adap = new SqlDataAdapter("select * from vista2", con);
            dt = new DataTable();
            adap.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
