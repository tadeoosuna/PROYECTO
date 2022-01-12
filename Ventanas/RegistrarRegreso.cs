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
    public partial class RegistrarRegreso : Form
    {
        SqlDataAdapter adap;
        DataTable dt;
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-JRQ86QG;Initial Catalog=BIBLIOTECA;Integrated Security=True;");
        SqlCommand cmd;


        public RegistrarRegreso()
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
            if (textBox1.Text == string.Empty || textBox2.Text == string.Empty)
            {
                MessageBox.Show("Llene los datos correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    con.Open();
                    cmd = new SqlCommand("exec P_AgregarStock '"+textBox1.Text+"','"+textBox2.Text+"'", con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Regreso Registrado");
                    textBox1.Clear();
                    textBox2.Clear();
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
