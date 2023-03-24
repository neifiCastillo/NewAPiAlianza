using System;
using System.Collections.Generic;

namespace API_Alianza.Models
{
    public partial class Region
    {
        public int Id { get; set; }
        public string? Descripcion { get; set; }
        public int? IdmacroRegion { get; set; }
    }
}
