using Domain.Entities;
using Domain.IRepositories;
using EntityFrameWorkCore.Data;

namespace EntityFrameWorkCore.Repositories
{
    public class RoleMenuRepository : RepositoryBase<RoleMenu>,IRoleMenuRepository
    {
        public RoleMenuRepository(WebContext db) : base(db)
        {
        }
    }
}
