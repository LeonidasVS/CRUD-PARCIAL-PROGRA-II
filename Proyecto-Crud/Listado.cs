﻿using DatosLayer;
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
            TablaPersonal.DataSource = ObtenerTodo;
        }

        private void tbFiltro_TextChanged(object sender, EventArgs e)
        {
          
            var ObtenerTodo = personarepo.ObtenerDatos();

            var filtro = ObtenerTodo.FindAll(f => f.CompanyName.StartsWith(tbFiltro.Text));
            TablaPersonal.DataSource = filtro;
        }

        private void TablaPersonal_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>=0 && e.ColumnIndex>=0)
            {
                int id = int.Parse(TablaPersonal.Rows[e.RowIndex].Cells["SupplierID"].Value.ToString());

                if (TablaPersonal.Columns[e.ColumnIndex].Name.Equals("Update"))
                {
                    //MessageBox.Show($"Se toco EDITAR con el id: {id} ");
                    MantenimientoPerson mante = new MantenimientoPerson(id);
                    mante.ShowDialog();
                    CargarDatos();
                }
                else if(TablaPersonal.Columns[e.ColumnIndex].Name.Equals("Delete"))
                {
                    MessageBox.Show($"Se toco ELIMINAR con el id: {id} ");
                }
            }
        }

        private void tbRecargar_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }
    }
}
