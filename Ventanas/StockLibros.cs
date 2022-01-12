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
    public partial class StockLibros : Form
    {
        SqlDataAdapter adap;
        DataTable dt;
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-JRQ86QG;Initial Catalog=BIBLIOTECA;Integrated Security=True;");
        SqlCommand cmd;

        public StockLibros()
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
                if (comboBox1.Text == "Id Libro")
                {
                    con.Open();
                    cmd = new SqlCommand("select * from stock where [idlibro] like '" + textBox1.Text + "'", con);
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    MessageBox.Show("Libro encontrado");
                    con.Close();
                    textBox1.Clear();

                }
            }
        }

        public void mostrarDatos() 
        {
            adap = new SqlDataAdapter("select * from stock", con);
            dt = new DataTable();
            adap.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GC.Collect();
            this.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            mostrarDatos();
        }
    }
}

