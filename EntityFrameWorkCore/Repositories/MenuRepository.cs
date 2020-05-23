using Domain.Entities;
using EntityFrameWorkCore.Data;
using Domain.IRepositories;
namespace EntityFrameWorkCore.Repositories
{
    public class MenuRepository : RepositoryBase<Menu>,IMenuRepository
    {
        public MenuRepository(WebContext db) : base(db)
        {
        }
    }
}
