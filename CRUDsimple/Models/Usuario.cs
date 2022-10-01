using System;
using System.Collections.Generic;

namespace CRUDsimple.Models
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Edad { get; set; } = null!;
        public string Ocupacion { get; set; } = null!;
        public string EstadoCivil { get; set; } = null!;
        public string Cedula { get; set; } = null!;
    }
}
