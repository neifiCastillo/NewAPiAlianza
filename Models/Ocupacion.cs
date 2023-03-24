using System;
using System.Collections.Generic;

namespace API_Alianza.Models
{
    public partial class Ocupacion
    {
        public short Id { get; set; }
        public string? Descripcion { get; set; }
        public string? RequiereTitulo { get; set; }
        public string? Estatus { get; set; }
        public Guid? RegId { get; set; }
    }
}
