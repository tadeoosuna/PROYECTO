using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoBD.Ventanas;
using System.Data.SqlClient;

namespace ProyectoBD.Ventanas
{
    public partial class Dashboard : Form
    {
        private Clientes c1;
        private Libros e1;
        private PrestarLibro p1;
        private BuscarCliente bc;
        private AgregarEmpleado ae;
        private BuscarEmpleado be;
        private BuscarLibro bl;
        private HistorialPrestamos hp;
        private RegistrarRegreso rr;

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-JRQ86QG;Initial Catalog=BIBLIOTECA;Integrated Security=True;");
        SqlCommand cmd;


        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            timer1.Start();
            toolStripLabel1.Text = "¡Bienvenido!";
            con.Open();
            cmd = new SqlCommand("EXEC P_ActualizarPrestamo",con);
            cmd.ExecuteNonQuery();
            con.Close();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripLabel2.Text = DateTime.Now.ToString();
        }

        private void nuevoClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            c1 = new Clientes();
            c1.ShowDialog();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void nuevoLibroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            e1 = new Libros();
            e1.ShowDialog();
        }

        private void buscarClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bc = new BuscarCliente();
            bc.ShowDialog();
        }

        private void conocenosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void prestarLibroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            p1 = new PrestarLibro();
            p1.ShowDialog();
        }

        private void historialDePrestamosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hp = new HistorialPrestamos();
            hp.ShowDialog();
        }

        private void buscarLibroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bl = new BuscarLibro();
            bl.ShowDialog();
        }

        private void nuevoEmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ae = new AgregarEmpleado();
            ae.ShowDialog();
        }

        private void buscarEmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            be = new BuscarEmpleado();
            be.ShowDialog();
        }

        private void registrarLibroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rr = new RegistrarRegreso();
            rr.ShowDialog();
        }

        private void stockDeLibrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StockLibros sl = new StockLibros();
            sl.ShowDialog();
        }
    }
}
