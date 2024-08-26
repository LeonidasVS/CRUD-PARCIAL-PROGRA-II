using DatosLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Crud
{
    public partial class Listado : Form
    {
        PersonaRepository personarepo = new PersonaRepository();
        public Listado()
        {
            InitializeComponent();
            CargarDatos();
        }

        private void CargarDatos()
        {
            var ObtenerTodo = personarepo.ObtenerDatos();
            dataGridView1.DataSource = ObtenerTodo;
        }

        private void tbFiltro_TextChanged(object sender, EventArgs e)
        {
          
            var ObtenerTodo = personarepo.ObtenerDatos();

            var filtro = ObtenerTodo.FindAll(f => f.CompanyName.StartsWith(tbFiltro.Text));
            dataGridView1.DataSource = filtro;
        }

    }
}
