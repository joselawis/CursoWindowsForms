using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CursoWindowsFormsApp
{
    public partial class Ejercicio1 : Form
    {
        private List<Empleado> empleados;
        private List<Modalidad> modalidades;

        public Ejercicio1()
        {
            InitializeComponent();
        }

        private void Ejercicio1_Load(object sender, EventArgs e)
        {
            empleados = new List<Empleado>
            {
                new Empleado(){idEmpleado=1 , nombre="Felipe" , apellidos="Contreras", idModalidad=1},
                new Empleado(){idEmpleado=2 , nombre="Josue" , apellidos="Lopez", idModalidad=2},
                new Empleado(){idEmpleado=3 , nombre="Enrique" , apellidos="Valle", idModalidad=2},
                new Empleado(){idEmpleado=4 , nombre="Carmen" , apellidos="Rojas", idModalidad=1},
                new Empleado(){idEmpleado=5 , nombre="Ricardo" , apellidos="Garma", idModalidad=3},
                new Empleado(){idEmpleado=6 , nombre="Rolando" , apellidos="Minchan", idModalidad=3}
            };

            modalidades = new List<Modalidad>()
            {
                new Modalidad(){idModalidad=1 , nombre="CAS"},
                new Modalidad(){idModalidad=2 , nombre="Temporal"},
                new Modalidad(){idModalidad=3 , nombre="Plazo Indeterminado"}
            };

            dgvEmpleados.DataSource = empleados;

            cbModalidad.DataSource = modalidades;
            cbModalidad.DisplayMember = "nombre";
            cbModalidad.ValueMember = "idModalidad";
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if ("".Equals(txtNombre.Text))
            {
                errorProvider1.SetError(txtNombre, "Ingrese nombre");
                return;
            }
            else
            {
                errorProvider1.SetError(txtNombre, "");
            }
            if ("".Equals(txtApellidos.Text))
            {
                errorProvider1.SetError(txtApellidos, "Ingrese Apellido");
                return;
            }
            else
            {
                errorProvider1.SetError(txtApellidos, "");
            }

            errorProvider1.Clear();
            int nextId = empleados.Max(emp => emp.idEmpleado + 1);
            empleados.Add(new Empleado() { idEmpleado = nextId, nombre = txtNombre.Text, apellidos = txtApellidos.Text, idModalidad=3 });

            dgvEmpleados.DataSource = null;
            dgvEmpleados.DataSource = empleados;

            txtNombre.Text = "";
            txtApellidos.Text = "";
        }

        private void buscarApellidos(object sender, EventArgs e)
        {
            IEnumerable<Empleado> consulta = from emp in empleados
                                             where emp.apellidos.ToUpper().Contains(txtApellidos.Text.ToUpper())
                                             select emp;

            dgvEmpleados.DataSource = null;
            dgvEmpleados.DataSource = consulta.ToList<Empleado>();
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            IEnumerable<Empleado> consulta = from emp in empleados
                                             where emp.idModalidad==int.Parse(cbModalidad.SelectedValue.ToString())
                                             select emp;

            dgvEmpleados.DataSource = null;
            dgvEmpleados.DataSource = consulta.ToList<Empleado>();
        }
    }
}
