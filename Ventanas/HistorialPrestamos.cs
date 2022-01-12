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
    public partial class HistorialPrestamos : Form
    {
        SqlDataAdapter adap;
        DataTable dt;
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-JRQ86QG;Initial Catalog=BIBLIOTECA;Integrated Security=True;");
        SqlCommand cmd;

        public HistorialPrestamos()
        {
            InitializeComponent();
            mostrarDatos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == String.Empty)
            {
                MessageBox.Show("Llene los datos correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (comboBox1.Text == "IdPrestamo")
                {
                    con.Open();
                    cmd = new SqlCommand("select * from PRESTAMOS where idprestamo like '" + textBox1.Text + "'", con);
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    MessageBox.Show("Datos encontrados");
                    con.Close();
                    textBox1.Clear();

                }
                else if (comboBox1.Text == "No. Empleado")
                {
                    con.Open();
                    cmd = new SqlCommand("select * from PRESTAMOS where numempleado like '" + textBox1.Text + "'", con);
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    MessageBox.Show("Datos encontrados");
                    con.Close();
                    textBox1.Clear();
                }
                else if (comboBox1.Text == "IdLibro")
                {
                    con.Open();
                    cmd = new SqlCommand("select * from PRESTAMOS where idlibro like '%" + textBox1.Text + "%'", con);
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
                    cmd = new SqlCommand("select * from PRESTAMOS where numcliente like '%" + textBox1.Text + "%'", con);
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

        private void button2_Click(object sender, EventArgs e)
        {
            GC.Collect();
            this.Dispose();
        }

        public void mostrarDatos() 
        {
            adap = new SqlDataAdapter("select * from prestamos", con);
            dt = new DataTable();
            adap.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            mostrarDatos();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
