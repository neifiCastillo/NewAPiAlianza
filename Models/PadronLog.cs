using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Alianza.Models
{
    public partial class PadronLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Method { get; set; }
        public string? Params { get; set; }
        public string? Message { get; set; }
        public DateTime? Fecha { get; set; }
        public bool Status { get; set; }
    }
}
