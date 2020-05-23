using Domain.Entities;
using Domain.IRepositories;
using EntityFrameWorkCore.Data;
using EntityFrameWorkCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;

namespace Application.WebUserApp
{
    //public class WebUserService : WebUserRepository, IWebUserService
    //{        
    //    public WebUserService(WebContext db) : base(db)
    //    {
    //    }


    //}
    public class WebUserService : IWebUserService
    {
        private readonly IWebUserRepository _webuser;
        public WebUserService(IWebUserRepository webuser)
        {
            _webuser = webuser;
        }
        public void add(WebUser webuser)
        {
            _webuser.Add(webuser,true);
        }

        public bool any(Expression<Func<WebUser, bool>> where)
        {
            return _webuser.Any(where);
        }

        public void delete(WebUser webuser)
        {
            _webuser.Delete(webuser,true);
        }

        public WebUser find(int id)
        {
            return _webuser.Find(id);
        }

        public WebUser firstordefault(Expression<Func<WebUser, bool>> where,bool isNotracking)
        {
            
            return _webuser.FirstOrDefault(where, isNotracking);
        }

        public List<WebUser> getallbypage(int pageindex, int pagesize)
        {
            return _webuser.GetAllByPage(pageindex, pagesize, true).ToList();
        }

        public int getcount()
        {
            return _webuser.Count();
        }

        public void update(WebUser webuser)
        {
            _webuser.Update(webuser,true);
        }
    }
}
