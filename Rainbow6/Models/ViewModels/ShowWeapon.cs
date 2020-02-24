using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rainbow6.Models.ViewModels
{
    public class ShowWeapon
    {
        public virtual Weapon Weapon { get; set; }
        public List<Operator> Operators { get; set; }
    }
}