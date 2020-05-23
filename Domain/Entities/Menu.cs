using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Menu
    {
        public int Id { get; set; }
        public string MenuName { get; set; }
        public string ParentName { get; set; }
        /// <summary>
        /// 0,1,2分别对应该导航菜单
        /// </summary>
        public int KindNum { get; set; }
        public string ActionName { get; set; }
        public string ControllerName { get; set; }
        public ICollection<RoleMenu> RoleMenu { get; set; }


    }
}
