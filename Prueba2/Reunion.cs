//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Prueba2
{
    using System;
    using System.Collections.Generic;
    
    public partial class Reunion
    {
        public int id_reunion { get; set; }
        public System.DateTime fecha { get; set; }
        public System.TimeSpan hora { get; set; }
        public string direccion { get; set; }
        public int id_empleado { get; set; }
    
        public virtual Empleado Empleado { get; set; }
    }
}
