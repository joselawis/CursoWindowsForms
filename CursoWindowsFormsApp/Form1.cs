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
    public partial class frmForm1 : Form
    {
        List<Categoria> listaCategoria;

        public frmForm1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Evento load, se activa cuando esta cargando
            listaCategoria = new List<Categoria>
            {
                new Categoria {idCategoria=1, nombreCategoria="Fruta"},
                new Categoria {idCategoria=2, nombreCategoria="Verdura"}
            };

            dgvCategoria.DataSource = listaCategoria;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                if ("".Equals(txtCategoria.Text))
                {
                    errorFormulario1.SetError(txtCategoria, "Ingrese categoria");
                    return;
                }
                else
                {
                    errorFormulario1.SetError(txtCategoria, "");
                }
                if ("".Equals(txtNombre.Text))
                {
                    errorFormulario1.SetError(txtNombre, "Ingrese Nombre");
                    return;
                }
                else
                {
                    errorFormulario1.SetError(txtNombre, "");
                }
                int idCategoria = int.Parse(txtCategoria.Text);
                string nombre = txtNombre.Text;

                Categoria cat = new Categoria();
                cat.idCategoria = idCategoria;
                cat.nombreCategoria = nombre;
                listaCategoria.Add(cat);

                dgvCategoria.DataSource = null;
                dgvCategoria.DataSource = listaCategoria;

                limpiarTextBox();
            }catch(Exception ex)
            {
                MessageBox.Show("Ocurrió un error");
            }
        }

        private void limpiarTextBox()
        {
            txtCategoria.Text = "";
            txtNombre.Text = "";
        }
    }
}
