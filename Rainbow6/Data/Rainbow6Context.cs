using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Rainbow6.Data
{
    public class Rainbow6Context : DbContext
    {
        public Rainbow6Context() : base("name=Rainbow6Context")
        {

        }

        public System.Data.Entity.DbSet<Rainbow6.Models.Operator> Operators { get; set; }
        public System.Data.Entity.DbSet<Rainbow6.Models.Weapon> Weapons { get; set; }
        public System.Data.Entity.DbSet<Rainbow6.Models.Position> Positions { get; set; }
        public System.Data.Entity.DbSet<Rainbow6.Models.Organization> Organizations { get; set; }
    }
}