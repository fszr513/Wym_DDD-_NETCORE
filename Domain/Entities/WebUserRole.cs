using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class WebUserRole
    {
        public int WebUserId { get; set; }
        public WebUser WebUser { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
