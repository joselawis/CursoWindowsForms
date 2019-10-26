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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Evento load, se activa cuando esta cargando
            List<Categoria> listaCategoria = new List<Categoria>
            {
                new Categoria {idCategoria=1, nombreCategoria="Fruta"},
                new Categoria {idCategoria=2, nombreCategoria="Verdura"}
            };

            dgvCategoria.DataSource = listaCategoria;
        }
    }
}
