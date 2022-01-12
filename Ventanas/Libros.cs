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
    public partial class Libros : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-JRQ86QG;Initial Catalog=BIBLIOTECA;Integrated Security=True;");
        SqlCommand cmd;

        public Libros()
        {
            InitializeComponent();
        }

        private void Empleados_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            GC.Collect();   
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty || textBox2.Text == string.Empty || textBox3.Text == string.Empty || textBox4.Text == string.Empty || textBox5.Text == string.Empty)
            {
                MessageBox.Show("Llene todos los datos");
            }
            else
            {
                con.Open();
                cmd = new SqlCommand("EXEC P_AgregarLibro '" + Int32.Parse(textBox1.Text) + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "', '" + Int32.Parse(textBox5.Text) + "' ", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Libro registrado con exito");
                con.Close();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
