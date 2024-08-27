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
        // Instancia de PersonaRepository, que se encarga de la lógica de acceso a datos de personas
        PersonaRepository persona = new PersonaRepository();

        // Variable para almacenar el ID de la persona que se está editando
        int id_ = 0;

        // Constructor de la clase MantenimientoPerson que acepta un ID opcional para modificar o agregar una persona
        public MantenimientoPerson(int id = 0)
        {
            InitializeComponent(); // Inicializa los componentes de la forma (ventana)
            id_ = id; // Asigna el ID pasado como parámetro a la variable id_

            // Verifica si el ID es mayor que 0, lo que indica que estamos en modo de edición
            if (id_ > 0)
            {
                // Cambia el título del formulario y el texto de un control para indicar que estamos editando un registro
                this.Text = "Modificar Personal";
                AñadorP.Text = "Edicion de Personal";
                // Oculta el botón de enviar datos porque no es necesario en modo de edición
                btnEnviarDatos.Hide();
                // Carga los datos de la persona a editar en los campos de texto
                CargarDatos();
            }
            else
            {
                // Oculta el botón de modificar si estamos en modo de adición
                btnModificar.Hide();
            }
        }

        // Método que crea un nuevo objeto Person con los datos introducidos en los campos de texto
        private Person ObtenerNuevoCliente()
        {
            var nuevoCliente = new Person
            {
                CompanyName = text1.Text,      // Nombre de la empresa
                ContactName = text2.Text,      // Nombre del contacto
                ContactTitle = text3.Text,     // Título del contacto
                City = text4.Text,             // Ciudad
                PostalCode = text5.Text,       // Código postal
                Country = text6.Text,          // País
                Phone = textBox7.Text          // Teléfono
            };
            return nuevoCliente; // Retorna el nuevo objeto Person
        }

        // Evento que se ejecuta cuando se hace clic en el botón de enviar datos (para agregar una nueva persona)
        private void btnEnviarDatos_Click(object sender, EventArgs e)
        {
            // Verifica que todos los campos de texto no estén vacíos
            if (text1.Text != "" && text2.Text != "" && text3.Text != "" && text4.Text != "" &&
                text5.Text != "" && text6.Text != "" && textBox7.Text != "")
            {
                var resultado = 0;
                // Obtiene el nuevo cliente a partir de los datos en los campos de texto
                var nuevoCliente = ObtenerNuevoCliente();
                // Llama al método para añadir el personal y obtiene el resultado
                resultado = persona.añadirPersonal(nuevoCliente);

                // Verifica si el resultado indica que la adición fue exitosa
                if (resultado == 1)
                {
                    // Muestra un mensaje de éxito y limpia todos los campos de texto
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
                // Muestra un mensaje de advertencia si algún campo de texto está vacío
                MessageBox.Show("Debes completar los campos vacios", "CAMPOS VACIOS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Método para cargar los datos de la persona a editar en los campos de texto
        public void CargarDatos()
        {
            // Obtiene la persona por ID desde la reposición de personas
            var perso = persona.ObtenerPorId(id_);

            // Asigna los datos de la persona a los campos de texto correspondientes
            text1.Text = perso.CompanyName;
            text2.Text = perso.ContactName;
            text3.Text = perso.ContactTitle;
            text4.Text = perso.City;
            text5.Text = perso.PostalCode;
            text6.Text = perso.Country;
            textBox7.Text = perso.Phone;
        }

        // Evento que se ejecuta cuando se hace clic en el botón de modificar (para actualizar una persona existente)
        private void btnModificar_Click(object sender, EventArgs e)
        {
            // Verifica que todos los campos de texto no estén vacíos
            if (text1.Text != "" && text2.Text != "" && text3.Text != "" && text4.Text != "" &&
                text5.Text != "" && text6.Text != "" && textBox7.Text != "")
            {
                // Obtiene los datos actualizados del cliente desde los campos de texto
                var update = ObtenerNuevoCliente();
                // Llama al método para actualizar el personal y obtiene el resultado
                int actulizar = persona.ActualizarPersonal(update, id_);

                // Verifica si la actualización fue exitosa
                if (actulizar > 0)
                {
                    // Muestra un mensaje de éxito y cierra el formulario
                    MessageBox.Show($"Se ha actualizado de forma EXITOSA", "Actualización", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    // Muestra un mensaje de error si la actualización falló
                    MessageBox.Show($"ERROR", "Actualización", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Muestra un mensaje de advertencia si hay campos vacíos
                MessageBox.Show("Debes completar los campos vacíos", "CAMPOS VACIOS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Evento que se ejecuta cuando se presiona una tecla en el campo de texto text5 (Código Postal)
        // Permite solo números y controles (por ejemplo, teclas de flecha, retroceso)
        private void text5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Cancela el evento de tecla si no es un número o un control
                e.Handled = true;
            }
        }

        // Evento que se ejecuta cuando se presiona una tecla en el campo de texto textBox7 (Teléfono)
        // Permite solo números y controles (por ejemplo, teclas de flecha, retroceso)
        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Cancela el evento de tecla si no es un número o un control
                e.Handled = true;
            }
        }

        // Evento que se ejecuta cuando se presiona una tecla en el campo de texto text6 (País)
        // Permite solo letras y caracteres de separación (espacios)
        private void text6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsSeparator(e.KeyChar))
            {
                // Cancela el evento de tecla si no es una letra o un carácter de separación
                e.Handled = true;
            }
        }

        // Evento que se ejecuta cuando se presiona una tecla en el campo de texto text4 (Ciudad)
        // Permite solo letras y caracteres de separación (espacios)
        private void text4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsSeparator(e.KeyChar))
            {
                // Cancela el evento de tecla si no es una letra o un carácter de separación
                e.Handled = true;
            }
        }

        // Evento que se ejecuta cuando se presiona una tecla en el campo de texto text2 (Nombre del Contacto)
        // Permite solo letras y caracteres de separación (espacios)
        private void text2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsSeparator(e.KeyChar))
            {
                // Cancela el evento de tecla si no es una letra o un carácter de separación
                e.Handled = true;
            }
        }

        // Evento que se ejecuta cuando se presiona una tecla en el campo de texto text1 (Nombre de la Empresa)
        // Permite solo letras y caracteres de separación (espacios)
        private void text1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsSeparator(e.KeyChar))
            {
                // Cancela el evento de tecla si no es una letra o un carácter de separación
                e.Handled = true;
            }
        }

        // Evento que se ejecuta cuando se presiona una tecla en el campo de texto text3 (Título del Contacto)
        // Permite letras, números y caracteres de separación (espacios)
        private void text3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar) && !char.IsSeparator(e.KeyChar))
            {
                // Cancela el evento de tecla si no es una letra, un número o un carácter de separación
                e.Handled = true;
            }
        }
    }
}
