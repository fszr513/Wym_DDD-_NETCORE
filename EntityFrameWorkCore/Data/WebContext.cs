using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameWorkCore.Data
{
    public class WebContext:DbContext
    {
        public WebContext(DbContextOptions<WebContext> options ):base(options)
        {
            
        }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RoleMenu> RoleMenus { get; set; }
        public DbSet<WebUser> WebUsers { get; set; }
        public DbSet<WebUserRole> WebUserRoles { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoleMenu>().HasKey(hk => new {hk.RoleId,hk.MenuId });
            modelBuilder.Entity<WebUserRole>().HasKey(hk => new { hk.WebUserId,hk.RoleId});
            base.OnModelCreating(modelBuilder);
        }
    }
}
