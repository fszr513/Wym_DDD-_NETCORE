using Domain.Entities;
using EntityFrameWorkCore.Data;
using Domain.IRepositories;

namespace EntityFrameWorkCore.Repositories
{
    public class RoleRepository : RepositoryBase<Role>, IRoleRepository
    {
        public RoleRepository(WebContext db) : base(db)
        {
        }
    }

    
}
