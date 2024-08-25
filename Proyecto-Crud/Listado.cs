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
            TextBox textBox = (TextBox)sender;
            string text = tbFiltro.Text;

            var ObtenerTodo = personarepo.ObtenerDatos();

            if (text.Length > 0)
            {
                string formateoTexto = char.ToUpper(text[0]) + text.Substring(1).ToLower();
                textBox.Text = formateoTexto;

                textBox.SelectionStart = textBox.Text.Length;

                var filtro =ObtenerTodo.FindAll(f => f.FirstName.StartsWith(tbFiltro.Text));
                dataGridView1.DataSource = filtro;
        }
    }

  }
}
