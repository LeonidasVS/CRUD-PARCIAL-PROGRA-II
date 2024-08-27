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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Crea una nueva instancia del formulario Listado
            Listado link = new Listado();

            // Muestra el formulario Listado como un cuadro de diálogo modal
            link.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Crea una nueva instancia del formulario MantenimientoPerson sin pasar un id
            MantenimientoPerson persona = new MantenimientoPerson();

            // Muestra el formulario MantenimientoPerson como un cuadro de diálogo modal
            persona.ShowDialog();
        }
    }
}
