using Domain.IRepositories;
using EntityFrameWorkCore.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace EntityFrameWorkCore.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly WebContext _db;
        public RepositoryBase(WebContext db)
        {
            _db = db;
        }
        public void Add(T t,bool isSave)
        {
            _db.Set<T>().Add(t);
            if (isSave)
            {
                SaveChanges();
            }
            
        }

        public bool Any(Expression<Func<T, bool>> whereLambda)
        {
            return _db.Set<T>().AsNoTracking().Any(whereLambda);
        }

        public int Count(Expression<Func<T, bool>> whereLambda)
        {
            return _db.Set<T>().AsNoTracking().Where(whereLambda).Count();
        }

        public int Count()
        {
            return _db.Set<T>().AsNoTracking().Count();
        }

        public void Delete(T t,bool isSave)
        {
            _db.Set<T>().Remove(t);
            if (isSave)
            {
                SaveChanges();
            }
        }

        public T Find(int id)
        {
            
            return _db.Set<T>().Find(id);
        }

        public T FirstOrDefault(bool isNoTracking)
        {
            if (isNoTracking)
            {
                return _db.Set<T>().AsNoTracking().FirstOrDefault();
            }
            else
            {
                return _db.Set<T>().FirstOrDefault();
            }
            
        }

        public T FirstOrDefault(Expression<Func<T, bool>> whereLambda, bool isNoTracking)
        {
            if (isNoTracking)
            {
                return _db.Set<T>().AsNoTracking().FirstOrDefault(whereLambda);
            }
            else
            {
                return _db.Set<T>().FirstOrDefault(whereLambda);
            }
            
        }

        public IQueryable<T> GetAll(bool isNoTracking)
        {
            if (isNoTracking)
            {
                return _db.Set<T>().AsNoTracking();
            }
            else
            {
                return _db.Set<T>();
            }
            
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> whereLambda, bool isNoTracking)
        {
            if (isNoTracking)
            {
                return _db.Set<T>().AsNoTracking().Where(whereLambda);
            }
            else
            {
                return _db.Set<T>().Where(whereLambda);
            }
            
        }

        public IQueryable<T> GetAll<OrderByT>(Expression<Func<T, bool>> whereLambda, bool isAsc, Expression<Func<T, OrderByT>> orderByLambda, bool isNoTracking)
        {
            if (isNoTracking)
            {
                if (isAsc)
                {
                    return _db.Set<T>().AsNoTracking().Where(whereLambda).OrderBy(orderByLambda);
                }
                else
                {
                    return _db.Set<T>().AsNoTracking().Where(whereLambda).OrderByDescending(orderByLambda);
                }
            }
            else
            {
                if (isAsc)
                {
                    return _db.Set<T>().Where(whereLambda).OrderBy(orderByLambda);
                }
                else
                {
                    return _db.Set<T>().Where(whereLambda).OrderByDescending(orderByLambda);
                }
            }
        }

        public IQueryable<T> GetAllByPage(int pageIndex,int pageSize,bool isNoTracking)
        {
            if (isNoTracking)
            {
                return _db.Set<T>().AsNoTracking().Skip(pageSize * (pageIndex - 1)).Take(pageSize);
            }
            else
            {
                return _db.Set<T>().Skip(pageSize * (pageIndex - 1)).Take(pageSize);
            }
        }

        public IQueryable<T> GetAllByPage(int pageIndex, int pageSize, Expression<Func<T, bool>> whereLambda, bool isNoTracking)
        {
            if (isNoTracking)
            {
                return _db.Set<T>().AsNoTracking().Where(whereLambda).Skip(pageSize * (pageIndex - 1)).Take(pageSize);
            }
            else
            {
                return _db.Set<T>().Where(whereLambda).Skip(pageSize * (pageIndex - 1)).Take(pageSize);
            }
        }

        public IQueryable<T> GetAllByPage<OrderByT>(int pageIndex, int pageSize, Expression<Func<T, bool>> whereLambda, bool isAsc, Expression<Func<T, OrderByT>> orderByLambda, bool isNoTracking)
        {
            if (isNoTracking)
            {
                if (isAsc)
                {
                    return _db.Set<T>().AsNoTracking().Where(whereLambda).OrderBy(orderByLambda).Skip(pageSize * (pageIndex - 1)).Take(pageSize);
                }
                else
                {
                    return _db.Set<T>().AsNoTracking().Where(whereLambda).OrderByDescending(orderByLambda).Skip(pageSize * (pageIndex - 1)).Take(pageSize);
                }
                
            }
            else
            {
                if (isAsc)
                {
                    return _db.Set<T>().Where(whereLambda).OrderBy(orderByLambda).Skip(pageSize * (pageIndex - 1)).Take(pageSize);
                }
                else
                {
                    return _db.Set<T>().Where(whereLambda).OrderByDescending(orderByLambda).Skip(pageSize * (pageIndex - 1)).Take(pageSize);
                }
            }
        }

        public bool SaveChanges()
        {
            return _db.SaveChanges() > 0;
        }

        public IQueryable<T> Top(int num, bool isNoTracking)
        {
            if (isNoTracking)
            {
                return _db.Set<T>().AsNoTracking().Take(num);
            }
            else
            {
                return _db.Set<T>().Take(num);
            }
        }

        public IQueryable<T> Top(int num, Expression<Func<T, bool>> whereLambda, bool isNoTracking)
        {
            if (isNoTracking)
            {
                return _db.Set<T>().AsNoTracking().Where(whereLambda).Take(num);
            }
            else
            {
                return _db.Set<T>().Where(whereLambda).Take(num);
            }
        }

        public IQueryable<T> Top<OrderByT>(int num, Expression<Func<T, bool>> whereLambda,bool isAsc, Expression<Func<T, OrderByT>> orderByLambda, bool isNoTracking)
        {
            if (isNoTracking)
            {
                if (isAsc)
                {
                    return _db.Set<T>().AsNoTracking().Where(whereLambda).OrderBy(orderByLambda).Take(num);
                }
                else
                {
                    return _db.Set<T>().AsNoTracking().Where(whereLambda).OrderByDescending(orderByLambda).Take(num);
                }
            }
            else
            {
                if (isAsc)
                {
                    return _db.Set<T>().Where(whereLambda).OrderBy(orderByLambda).Take(num);
                }
                else
                {
                    return _db.Set<T>().Where(whereLambda).OrderByDescending(orderByLambda).Take(num);
                }
            }
        }

        public void Update(T t,bool isSave)
        {
            _db.Set<T>().Update(t);
            if (isSave)
            {
                SaveChanges();
            }
        }
    }
}
