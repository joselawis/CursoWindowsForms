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
            Categoria cat = new Categoria();
            cat.idCategoria = int.Parse(txtCategoria.Text);
            cat.nombreCategoria = txtNombre.Text;

            listaCategoria.Add(cat);
            dgvCategoria.DataSource = null;
            dgvCategoria.DataSource = listaCategoria;

            limpiarTextBox();
        }

        private void limpiarTextBox()
        {
            txtCategoria.Text = "";
            txtNombre.Text = "";
        }
    }
}
