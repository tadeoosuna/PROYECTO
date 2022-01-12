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
    public partial class AgregarEmpleado : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-JRQ86QG;Initial Catalog=BIBLIOTECA;Integrated Security=True;");
        SqlCommand cmd;

        public AgregarEmpleado()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GC.Collect();
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("exec P_AgregarEmpleado '" + Int32.Parse(textBox1.Text) + "','" + textBox2.Text + "','" + textBox3.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "', '" + textBox6.Text + "'", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Datos registrados con exito");
                con.Close();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                
            }
            
        }
    }
}
