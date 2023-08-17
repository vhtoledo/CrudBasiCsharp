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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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

        // Metodo actualizar registro
        private void button2_Click(object sender, EventArgs e)
        {
            BD.Conexion();
            string update = "UPDATE Empleados SET codigo=@codigo, nombre=@nombre, apellido=@apellido, direccion=@direccion WHERE codigo=@codigo";
            SqlCommand actualizar = new SqlCommand(update, BD.Conexion());
            actualizar.Parameters.AddWithValue("@codigo", textCodigo.Text);
            actualizar.Parameters.AddWithValue("@nombre", textNombre.Text);
            actualizar.Parameters.AddWithValue("@apellido", textApellido.Text);
            actualizar.Parameters.AddWithValue("@direccion", textDireccion.Text);

            actualizar.ExecuteNonQuery();

            MessageBox.Show("Actualización correctamente");

            dataGridView1.DataSource = Consulta();
        }

        // Metodo para recuperar datos en las posiciones
        void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textCodigo.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textNombre.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textApellido.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textDireccion.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BD.Conexion();
            string delete = "DELETE FROM Empleados WHERE codigo=@codigo";
            SqlCommand eliminar = new SqlCommand(delete, BD.Conexion());
            eliminar.Parameters.AddWithValue("@codigo", textCodigo.Text);
            eliminar.ExecuteNonQuery();
            MessageBox.Show("El empleado se eliminó correctamente");
            dataGridView1.DataSource = Consulta();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textCodigo.Clear();
            textNombre.Clear();
            textApellido.Clear();
            textDireccion.Clear();
            textNombre.Focus();
        }
    }
}
