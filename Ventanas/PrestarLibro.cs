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
    public partial class PrestarLibro : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-JRQ86QG;Initial Catalog=BIBLIOTECA;Integrated Security=True;");
        SqlCommand cmd = new SqlCommand();   
        SqlDataAdapter adap = new SqlDataAdapter();
        DataTable datos = new DataTable();  

        public PrestarLibro()
        {
            InitializeComponent();
            autocompletarCliente();
            autocompletarLibro();
            autocompletarEmpleado();
        }

        private void PrestarLibro_Load(object sender, EventArgs e)
        {
               
        }

        public void autocompletarEmpleado()
        {
            cmd = new SqlCommand("select numempleado from EMPLEADOS", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            AutoCompleteStringCollection lista = new AutoCompleteStringCollection();

            while (dr.Read())
            {
                lista.Add(dr.GetInt32(0).ToString());
            }
            textBox1.AutoCompleteCustomSource = lista;
            con.Close();
        }

        public void autocompletarCliente()
        {
            cmd = new SqlCommand("select numcliente from CLIENTES",con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            AutoCompleteStringCollection lista = new AutoCompleteStringCollection();

            while (dr.Read())
            {
                lista.Add(dr.GetInt32(0).ToString());
            }
            textBox2.AutoCompleteCustomSource = lista;
            con.Close();
        }


        public void autocompletarLibro()
        {

            cmd = new SqlCommand("select idlibro from LIBROS", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            AutoCompleteStringCollection lista = new AutoCompleteStringCollection();

            while (dr.Read())
            {
                lista.Add(dr.GetInt32(0).ToString());
            }
            textBox3.AutoCompleteCustomSource = lista;
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GC.Collect();
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty || textBox2.Text == string.Empty || textBox3.Text == string.Empty || textBox4.Text == string.Empty)
            {
                MessageBox.Show("Llene todos los datos");
            }
            else
            {
                try
                {
                    con.Open();
                    cmd = new SqlCommand("exec P_AgregarPrestamo '" + textBox4.Text + "', '" + textBox1.Text + "', '" + textBox3.Text + "', '" + textBox2.Text + "'", con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Datos registrados con exito");
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                    con.Close();
                }
                
            }
            
        }

   
    }

    
}
