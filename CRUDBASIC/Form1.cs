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

namespace CRUDBASIC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Sincronizar conexión BD
            BD.Conexion();
            MessageBox.Show("Conectado");

            dataGridView1.DataSource = Consulta();

        }
        // Crear metodo de consulta
        public DataTable Consulta()
        {
            BD.Conexion();
            DataTable datos = new DataTable();
            string consultar = "SELECT * FROM Empleados";
            SqlCommand cmd = new SqlCommand(consultar, BD.Conexion());
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(datos);
            return datos;
        }
        
        // Crear metodo de registro
        private void button1_Click(object sender, EventArgs e)
        {
            BD.Conexion();
            string insertar = "INSERT INTO Empleados(codigo,nombre,apellido,direccion) VALUES (@codigo,@nombre,@apellido,@direccion)";
            SqlCommand insert = new SqlCommand(insertar,BD.Conexion());
            insert.Parameters.AddWithValue("@codigo", textCodigo.Text);
            insert.Parameters.AddWithValue("@nombre", textNombre.Text);
            insert.Parameters.AddWithValue("@apellido", textApellido.Text);
            insert.Parameters.AddWithValue("@direccion", textDireccion.Text);

            insert.ExecuteNonQuery();

            MessageBox.Show("Empleado registrado");

            dataGridView1.DataSource = Consulta();

        }
    }
}
