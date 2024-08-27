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
        int id_ = 0;
        public MantenimientoPerson(int id=0)
        {
            InitializeComponent();
            id_ = id;
            if (id_>0)
            {
                this.Text = "Modificar Personal";
                AñadorP.Text = "Edicion de Personal";
                btnEnviarDatos.Hide();
                CargarDatos();
            }
            else
            {
                btnModificar.Hide();
            }
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
        private void btnEnviarDatos_Click(object sender, EventArgs e)
        {
            if (text1.Text!="" && text2.Text != "" && text3.Text != "" && text4.Text != "" &&
                text5.Text != "" && text6.Text != "" && textBox7.Text != "")
            {
                var resultado = 0;
                var nuevoCliente = ObtenerNuevoCliente();
                resultado = persona.añadirPersonal(nuevoCliente);

                if (resultado == 1)
                {
                    MessageBox.Show("Personal Agregado con EXITO", "Añadir Personal", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("Debes completar los campos vacios", "CAMPOS VACIOS",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        public void CargarDatos()
        {
            var perso=persona.ObtenerPorId(id_);

            text1.Text = perso.CompanyName;
            text2.Text = perso.ContactName;
            text3.Text = perso.ContactTitle;
            text4.Text = perso.City;
            text5.Text = perso.PostalCode;
            text6.Text = perso.Country;
            textBox7.Text = perso.Phone;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (text1.Text != "" && text2.Text != "" && text3.Text != "" && text4.Text != "" &&
                text5.Text != "" && text6.Text != "" && textBox7.Text != "")
            {
                var update = ObtenerNuevoCliente();
                int actulizar = persona.ActualizarPersonal(update, id_);

                if (actulizar > 0)
                {
                    MessageBox.Show($"Se ha actualizado de forma EXITOSA", "Actulizacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show($"ERROR", "Actulizacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Debes completar los campos vacios", "CAMPOS VACIOS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void text5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void text6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsSeparator(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void text4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsSeparator(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void text2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsSeparator(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void text1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsSeparator(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void text3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar) && !char.IsSeparator(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
