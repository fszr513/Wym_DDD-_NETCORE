using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    public class WebUser
    {
        public int Id { get; set; }
        public string  Name { get; set; }
        public string LogUserId { get; set; }
        public string LogUserPassword { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime RegTime { get; set; }
        public string RegIp { get; set; }
        public string LoginIp { get; set; }
        public int ErrorLoginCount { get; set; }
        public bool IsLock { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime LockTime { get; set; }
        
        public string Token { get; set; }       
        public ICollection<WebUserRole> WebUserRole { get; set; }
    }
}
