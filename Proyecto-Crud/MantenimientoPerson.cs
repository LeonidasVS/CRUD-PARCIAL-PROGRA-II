using DatosLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Crud
{
    public partial class MantenimientoPerson : Form
    {
        PersonaRepository persona = new PersonaRepository();
        public MantenimientoPerson()
        {
            InitializeComponent();
        }

        private Person ObtenerNuevoCliente()
        {

            var nuevoCliente = new Person
            {
               CompanyName=text1.Text,
               ContactName=text2.Text,
               ContactTitle=text3.Text,
               City=text4.Text,
               PostalCode=text5.Text,
               Country=text6.Text,
               Phone=textBox7.Text
            };
            return nuevoCliente;
        }

        public Boolean validarCampoNull(Object objeto)
        {

            foreach (PropertyInfo property in objeto.GetType().GetProperties())
            {
                object value = property.GetValue(objeto, null);
                if (value=="")
                {
                    return true;
                }
            }
            return false;
        }

        private void btnEnviarDatos_Click(object sender, EventArgs e)
        {
            var resultado = 0;
            

            var nuevoCliente = ObtenerNuevoCliente();

            if (validarCampoNull(nuevoCliente) == false)
            {
                resultado = persona.añadirPersonal(nuevoCliente);

                if (resultado==1)
                {
                    MessageBox.Show("Personal Agregado con EXITO","Añadir Personal",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    text1.Text = "";
                    text2.Text = "";
                    text3.Text = "";
                    text4.Text = "";
                    text5.Text = "";
                    text6.Text = "";
                    textBox7.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Completa los campos vacios", "Añadir Personal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
