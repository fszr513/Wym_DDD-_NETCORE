using Domain.Entities;
using Domain.IRepositories;
using EntityFrameWorkCore.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameWorkCore.Repositories
{
    public class WebUserRoleRepository : RepositoryBase<WebUserRole>, IWebUserRoleRepository
    {
        public WebUserRoleRepository(WebContext db) : base(db)
        {
        }
    }
}
