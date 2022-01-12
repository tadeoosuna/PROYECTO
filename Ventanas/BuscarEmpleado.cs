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
    public partial class BuscarEmpleado : Form
    {
        SqlDataAdapter adap;
        DataTable dt;
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-JRQ86QG;Initial Catalog=BIBLIOTECA;Integrated Security=True;");
        SqlCommand cmd;

        public BuscarEmpleado()
        {
            InitializeComponent();
            mostrarDatos();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = dataGridView1.SelectedCells[0].Value.ToString();
            textBox3.Text = dataGridView1.SelectedCells[1].Value.ToString();
            textBox4.Text = dataGridView1.SelectedCells[2].Value.ToString();
            textBox5.Text = dataGridView1.SelectedCells[3].Value.ToString();
            textBox6.Text = dataGridView1.SelectedCells[4].Value.ToString();
            textBox7.Text = dataGridView1.SelectedCells[5].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == string.Empty || textBox3.Text == string.Empty || textBox4.Text == string.Empty || textBox5.Text == string.Empty || textBox6.Text == string.Empty || textBox7.Text == string.Empty)
            {
                MessageBox.Show("Llene los datos correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                con.Open();
                cmd = new SqlCommand("EXEC P_ModificarEmpleado '" + Int32.Parse(textBox2.Text) + "', '" + textBox3.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "', '" + textBox6.Text + "', '"+textBox7.Text+"' ", con);
                cmd.ExecuteNonQuery();
                con.Close();
                mostrarDatos();
                limpiar();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GC.Collect();
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("Llene los datos correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                con.Open();
                cmd = new SqlCommand("exec P_MostrarEmpleado '" + textBox1.Text + "'", con);
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

        public void mostrarDatos()
        {
            adap = new SqlDataAdapter("select numempleado as 'No. Empleado', nombempleado as 'Nombre', fechanacimiento as 'Fecha de nacimiento', direccionemp as 'Direccion', telefonoemp as 'Telefono', correoemp as 'Correo Electronico' from EMPLEADOS", con);
            dt = new DataTable();
            adap.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            mostrarDatos();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == string.Empty || textBox3.Text == string.Empty || textBox4.Text == string.Empty || textBox5.Text == string.Empty || textBox6.Text == string.Empty)
            {
                MessageBox.Show("Llene los datos correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    con.Open();
                    cmd = new SqlCommand("EXEC P_EliminarEmpleado '" + Int32.Parse(textBox2.Text) + "'", con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Empleado eliminado con exito");
                    mostrarDatos();
                    limpiar();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                    con.Close();
                }               
            }
        }

        public void limpiar()
        {
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
        }
    }
}
