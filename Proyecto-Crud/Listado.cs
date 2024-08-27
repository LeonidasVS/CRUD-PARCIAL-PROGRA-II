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
    // Definición de la clase Listado que hereda de Form
    public partial class Listado : Form
    {
        // Instancia de PersonaRepository, que probablemente maneja el acceso a datos de personas
        PersonaRepository personarepo = new PersonaRepository();

        // Constructor de la clase Listado
        public Listado()
        {
            InitializeComponent(); // Inicializa los componentes de la forma (ventana)
            CargarDatos(); // Llama al método para cargar los datos en la tabla al inicio
        }

        // Método para cargar los datos en la tabla
        private void CargarDatos()
        {
            // Obtiene todos los datos de la reposición de personas
            var ObtenerTodo = personarepo.ObtenerDatos();
            // Asigna los datos obtenidos como origen de datos de la tabla (DataGridView)
            TablaPersonal.DataSource = ObtenerTodo;
        }

        // Evento que se ejecuta cuando el texto en el cuadro de filtro cambia
        private void tbFiltro_TextChanged(object sender, EventArgs e)
        {
            // Obtiene todos los datos de la reposición de personas
            var ObtenerTodo = personarepo.ObtenerDatos();

            // Filtra los datos basados en si el nombre de la empresa empieza con el texto del filtro
            var filtro = ObtenerTodo.FindAll(f => f.CompanyName.StartsWith(tbFiltro.Text));
            // Actualiza la tabla con los datos filtrados
            TablaPersonal.DataSource = filtro;
        }

        // Evento que se ejecuta cuando se hace clic en una celda de la tabla
        private void TablaPersonal_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica que el clic se haya realizado en una fila y columna válida
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Obtiene el ID del personal seleccionado desde la celda "SupplierID"
                int id = int.Parse(TablaPersonal.Rows[e.RowIndex].Cells["SupplierID"].Value.ToString());

                // Verifica si la columna clickeada es "Update"
                if (TablaPersonal.Columns[e.ColumnIndex].Name.Equals("Update"))
                {
                    // Crea una instancia de la ventana de mantenimiento de persona, pasándole el ID
                    MantenimientoPerson mante = new MantenimientoPerson(id);
                    mante.ShowDialog(); // Muestra la ventana de diálogo para actualización
                    CargarDatos(); // Recarga los datos en la tabla
                }
                // Verifica si la columna clickeada es "Delete"
                else if (TablaPersonal.Columns[e.ColumnIndex].Name.Equals("Delete"))
                {
                    // Muestra un cuadro de mensaje para confirmar la eliminación
                    var resultado = MessageBox.Show("¿Deseas Eliminar el personal?", "Personal DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    // Si el usuario confirma la eliminación
                    if (resultado == DialogResult.Yes)
                    {
                        // Llama al método de eliminación de personal y obtiene el número de registros eliminados
                        int elimindas = personarepo.EleminarPersonal(id);
                        // Verifica si se eliminó al menos un registro
                        if (elimindas > 0)
                        {
                            // Muestra un mensaje de éxito si la eliminación fue exitosa
                            MessageBox.Show("Personal Eliminado con Exito", "ELimnar Personal", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargarDatos(); // Recarga los datos en la tabla
                        }
                        else
                        {
                            // Muestra un mensaje de error si la eliminación no fue exitosa
                            MessageBox.Show("El personal no FUE ELIMINADO", "ELimnar Personal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        // Evento que se ejecuta al hacer clic en el botón de recargar
        private void tbRecargar_Click(object sender, EventArgs e)
        {
            CargarDatos(); // Llama al método para recargar los datos en la tabla
        }
    }
}
