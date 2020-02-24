using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Rainbow6.Models
{
    public class Organization
    {
        [Key]
        public int OrganizationID { get; set; }
        public string ShortName { get; set; }
        public string Name { get; set; }
        public string IngameDescription { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}