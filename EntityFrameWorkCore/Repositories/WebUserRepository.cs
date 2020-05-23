using Domain.Entities;
using Domain.IRepositories;
using EntityFrameWorkCore.Data;

namespace EntityFrameWorkCore.Repositories
{
    public class WebUserRepository : RepositoryBase<WebUser>,IWebUserRepository
    {
        public WebUserRepository(WebContext db) : base(db)
        {
        }
    }
}
