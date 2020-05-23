using Domain.Entities;
using Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Application.WebUserApp
{

    //public interface IWebUserService:IWebUserRepository
    //{
    //    //省事的话直接继承 dal层的接口，但如果 按松耦合的方式 ，不是继承而是注入 对应的接口
    //    //List<WebUser> getAllByPage(int pageIndex, int pageSize);
    //    //int getCount();
    //    //void Add(WebUser webUser);
    //    //WebUser
    //}
    public interface IWebUserService
    {
        List<WebUser> getallbypage(int pageindex, int pagesize);
        int getcount();
        void add(WebUser webuser);
        void update(WebUser webuser);
        void delete(WebUser webuser);
        WebUser find(int id);
        WebUser firstordefault(Expression<Func<WebUser, bool>> where,bool isNotracking);
        bool any(Expression<Func<WebUser, bool>> where);
    }
}
