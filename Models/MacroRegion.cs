using System;
using System.Collections.Generic;

namespace API_Alianza.Models
{
    public partial class MacroRegion
    {
        public int Id { get; set; }
        public string? Descripcion { get; set; }
        public Guid? RegId { get; set; }
    }
}
