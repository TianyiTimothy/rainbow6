using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rainbow6.Models.ViewModels
{
    public class ShowOperator
    {
        public virtual Operator Operator { get; set; }
        public List<Weapon> Weapons { get; set; }
    }
}