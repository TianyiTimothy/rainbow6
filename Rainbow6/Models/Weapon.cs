using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Rainbow6.Models
{
    public class Weapon
    {
        [Key]
        public int WeaponID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string IngameDescription { get; set; }
        public string Description { get; set; }
        public string FireMode { get; set; }
        public string BackgroundImageUrl { get; set; }
        public string ImageUrl { get; set; }


        // many to many
        public ICollection<Operator> Operators { get; set; }
    }
}