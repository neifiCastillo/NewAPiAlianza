using System;
using System.Collections.Generic;

namespace API_Alianza.Models
{
    public partial class Paise
    {
        public int CodPais { get; set; }
        public string? Nombre { get; set; }
        public string? Iso { get; set; }
        public string? Continente { get; set; }
        public string? DependenciaIso { get; set; }
        public string? Estatus { get; set; }
        public string? NombreOld { get; set; }
        public int? IdipPais { get; set; }
        public string? CodProvincia { get; set; }
        public int Id { get; set; }
        public int? IdAreaTrabajoCentroCercano { get; set; }
        public int? IdOclee { get; set; }
    }
}
