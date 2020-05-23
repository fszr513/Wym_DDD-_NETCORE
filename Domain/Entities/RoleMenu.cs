using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class RoleMenu
    {
        public int MenuId { get; set; }
        public Menu Menu { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
