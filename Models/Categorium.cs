using System;
using System.Collections.Generic;

namespace API_Alianza.Models
{
    public partial class Categorium
    {
        public short Id { get; set; }
        public string? Descripcion { get; set; }
        public string? LlevaColegio { get; set; }
        public string? PuedeVotar { get; set; }
        public string? LlevaDatosActa { get; set; }
        public string? LlevaDatosPasaporte { get; set; }
        public Guid? RegId { get; set; }
    }
}
