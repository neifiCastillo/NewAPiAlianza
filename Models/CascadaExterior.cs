using System;
using System.Collections.Generic;

namespace API_Alianza.Models
{
    public partial class CascadaExterior
    {
        public int CodPais { get; set; }
        public string? NombrePais { get; set; }
        public int? IdOclee { get; set; }
        public string Oclee { get; set; } = null!;
        public int CodNivel1 { get; set; }
        public string Nivel1 { get; set; } = null!;
        public int? CodNivel2 { get; set; }
        public string? Nivel2 { get; set; }
        public int? CodNivel3 { get; set; }
        public string? Nivel3 { get; set; }
        public string Estatus { get; set; } = null!;
    }
}
