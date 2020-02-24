using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Rainbow6.Models
{
    public class Operator
    {
        [Key]
        public int OperatorID { get; set; }
        public string Alias { get; set; }
        public string Name { get; set; }
        public int BirthYear { get; set; }
        public int BirthMonth { get; set; }
        public int BirthDay { get; set; }
        public string BirthPlace { get; set; }
        //height is in cm
        public int Height { get; set; }
        //weight is in kg
        public int Weight { get; set; }
        public string Biography { get; set; }
        public string UniqueAbility { get; set; }
        public string UniqueAbilityDescription { get; set; }
        public string UniqueAbilityImageUrl { get; set; }
        public string BackgroundImageUrl { get; set; }
        public string LogoImageUrl { get; set; }
        public string ImageUrl { get; set; }
        public string EliteImageUrl { get; set; }

        // one to many
        public int OrganizationID { get; set; }
        [ForeignKey("OrganizationID")]
        public virtual Organization Organizations { get; set; }

        // one to many
        public int PositionID { get; set; }
        [ForeignKey("PositionID")]
        public virtual Position Positions { get; set; }

        // many to many
        public ICollection<Weapon> Weapons { get; set; }


    }
}