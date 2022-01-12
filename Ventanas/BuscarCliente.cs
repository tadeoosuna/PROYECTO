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
    public partial class BuscarCliente : Form
    {
        SqlDataAdapter adap;
        DataTable dt;
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-JRQ86QG;Initial Catalog=BIBLIOTECA;Integrated Security=True;");
        SqlCommand cmd;

        public BuscarCliente()
        {
            InitializeComponent();
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
                MessageBox.Show("Llene los datos correctamente","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                con.Open();
                cmd = new SqlCommand("exec P_MostrarCliente '"+Int32.Parse(textBox1.Text)+"'", con);
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
            adap = new SqlDataAdapter("select numcliente as 'Numero cliente', nombrecli as 'Nombre cliente', telefonocli as 'Telefono cliente', correocli as 'Correo cliente', direccioncli as 'Direccion cliente' from CLIENTES", con);
            dt = new DataTable();
            adap.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void BuscarCliente_Load(object sender, EventArgs e)
        {
            mostrarDatos();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = dataGridView1.SelectedCells[0].Value.ToString();
            textBox3.Text = dataGridView1.SelectedCells[1].Value.ToString();
            textBox4.Text = dataGridView1.SelectedCells[2].Value.ToString();
            textBox5.Text = dataGridView1.SelectedCells[3].Value.ToString();
            textBox6.Text = dataGridView1.SelectedCells[4].Value.ToString();
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
                con.Open();
                cmd = new SqlCommand("EXEC P_EliminarCliente '" + Int32.Parse(textBox2.Text) + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Cliente eliminado con exito");
                mostrarDatos();
                limpiar();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == string.Empty || textBox3.Text == string.Empty || textBox4.Text == string.Empty || textBox5.Text == string.Empty || textBox6.Text == string.Empty)
            {
                MessageBox.Show("Llene los datos correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                con.Open();
                cmd = new SqlCommand("EXEC P_ModificarCliente '" + Int32.Parse(textBox2.Text) + "', '" + textBox3.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "', '" + textBox6.Text + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Cliente modificado con exito");
                mostrarDatos();
                limpiar();
            }
        }

        public void limpiar()
        {
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Estados es = new Estados();
            es.ShowDialog();
        }
    }
}
