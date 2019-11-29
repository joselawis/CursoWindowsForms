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
    public partial class frmForm4 : Form
    {
        List<Categoria> categorias;

        public frmForm4()
        {
            InitializeComponent();
            Load += new EventHandler(Form4_Load);
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // Evento load, se activa cuando esta cargando
            categorias = new List<Categoria>
            {
                new Categoria {idCategoria=1, nombreCategoria="Fruta"},
                new Categoria {idCategoria=2, nombreCategoria="Verdura"},
                new Categoria {idCategoria=3, nombreCategoria="Lapices"},
                new Categoria {idCategoria=4, nombreCategoria="Gatos"},
                new Categoria {idCategoria=5, nombreCategoria="Zombies"}

            };

            dgvCategoria.DataSource = categorias;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            IEnumerable<Categoria> consulta = from categoria in categorias
                                              where categoria.nombreCategoria.Equals(nombre)
                                              select categoria;

            dgvCategoria.DataSource = consulta.ToList<Categoria>();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            dgvCategoria.DataSource = categorias;
            txtNombre.Text = "";
        }

        private void filtrar(object sender, EventArgs e)
        {
            IEnumerable<Categoria> consulta = from categoria in categorias
                                              where categoria.nombreCategoria.ToUpper().Contains(txtNombre.Text.ToUpper())
                                              select categoria;
            dgvCategoria.DataSource = consulta.ToList<Categoria>();
        }
    }
}
