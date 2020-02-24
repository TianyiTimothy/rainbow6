using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Rainbow6.Models
{
    public class Position
    {
        [Key]
        public int PositionID { get; set; }
        // Attacker | Defender
        public string Type { get; set; }
    }
}