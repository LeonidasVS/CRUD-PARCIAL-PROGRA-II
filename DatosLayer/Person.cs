using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosLayer
{
    // Clase que representa a un proveedor o contacto en el sistema
    public class Person
    {
        // Identificador único del proveedor o contacto
        public int SupplierID { get; set; }

        // Nombre de la empresa del proveedor o contacto
        public string CompanyName { get; set; }

        // Nombre del contacto en la empresa
        public string ContactName { get; set; }

        // Título o cargo del contacto en la empresa
        public string ContactTitle { get; set; }

        // Dirección física del proveedor o contacto
        public string Address { get; set; }

        // Ciudad donde se encuentra el proveedor o contacto
        public string City { get; set; }

        // Región o estado donde se encuentra el proveedor o contacto
        public string Region { get; set; }

        // Código postal del proveedor o contacto
        public string PostalCode { get; set; }

        // País donde se encuentra el proveedor o contacto
        public string Country { get; set; }

        // Número de teléfono del proveedor o contacto
        public string Phone { get; set; }

        // Número de fax del proveedor o contacto
        public string Fax { get; set; }

        // Página web del proveedor o contacto
        public string HomePage { get; set; }
    }

}
