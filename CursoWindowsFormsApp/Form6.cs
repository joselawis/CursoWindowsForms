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
    public partial class Form6 : Form
    {
        private List<Producto> productos;
        private List<Categoria> categorias;

        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            // Combobox
            categorias = new List<Categoria>
            {
                new Categoria {idCategoria=1, nombreCategoria="Fruta"},
                new Categoria {idCategoria=2, nombreCategoria="Verdura"},
                new Categoria {idCategoria=3, nombreCategoria="Lapices"},
                new Categoria {idCategoria=4, nombreCategoria="Gatos"},
                new Categoria {idCategoria=5, nombreCategoria="Zombies"}

            };
            cbCategoria.DataSource = categorias;
            cbCategoria.DisplayMember = "nombreCategoria";
            cbCategoria.ValueMember = "idCategoria";

            // Data Grid
            productos = new List<Producto>()
            {
                new Producto { idProducto = 1, nombre="Papaya", idCategoria=1 },
                new Producto { idProducto = 2, nombre="Uva", idCategoria=1},
                new Producto { idProducto = 3, nombre="Platano", idCategoria=1},
                new Producto { idProducto = 4, nombre="Lechuga", idCategoria=2},
                new Producto { idProducto = 5 , nombre="Cebolla", idCategoria=2},
                new Producto { idProducto = 6, nombre="Ajo", idCategoria=2}
            };
            dgvProductos.DataSource = productos;
        }

        private void filtrar(object sender, EventArgs e)
        {
            int id = int.Parse(cbCategoria.SelectedValue.ToString());
            IEnumerable<Producto> consulta = from producto in productos
                                             where producto.idCategoria.Equals(id)
                                             select producto;

            dgvProductos.DataSource = consulta.ToList<Producto>();
        }
    }
}
