using System;
using System.Collections.Generic;

namespace API_Alianza.Models
{
    public partial class CancelacionTipoCausa
    {
        public short Id { get; set; }
        public string? Descripcion { get; set; }
        public string? Codigo { get; set; }
        public Guid? RegId { get; set; }
    }
}
