using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public int WebUseId { get; set; }
        public ICollection<RoleMenu> RoleMunu { get; set; }
        public ICollection<WebUserRole> WebUserRole { get; set; }
    }
}
