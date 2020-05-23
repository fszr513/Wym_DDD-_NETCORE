using System;
using System.Linq;
using System.Linq.Expressions;

namespace Domain.IRepositories
{
    public interface IRepositoryBase<T> where T:class
    {
        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="t"></param>
        /// <param name="isSave">是否保存，true为保存，false 不保存</param>
        void Add(T t,bool isSave);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="t"></param>
        /// <param name="isSave">是否保存，true为保存，false 不保存</param>
        void Delete(T t, bool isSave);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="t"></param>
        /// <param name="isSave">是否保存，true为保存，false 不保存</param>
        void Update(T t, bool isSave);

        /// <summary>
        /// 查询所有
        /// </summary>
        /// <param name="isNoTracking">是否不跟踪查询（true不跟踪，false跟踪）</param>
        /// <returns></returns>
        IQueryable<T> GetAll(bool isNoTracking);

        /// <summary>
        /// 查询所有
        /// </summary>
        /// <param name="whereLambda">where查询lambda表达式</param>
        /// <param name="isNoTracking">是否不跟踪查询（true不跟踪，false跟踪）</param>
        /// <returns></returns>
        IQueryable<T> GetAll(Expression<Func<T,bool>> whereLambda, bool isNoTracking);

        /// <summary>
        /// 查询所有
        /// </summary>
        /// <typeparam name="OrderByT"></typeparam>
        /// <param name="whereLambda">where查询lambda表达式</param>
        /// <param name="isAsc">是否按Asc排序</param>
        /// <param name="orderByLambda">orderby查询lambda表达式</param>
        /// <param name="isNoTracking">是否不跟踪查询（true不跟踪，false跟踪）</param>
        /// <returns></returns>
        IQueryable<T> GetAll<OrderByT>(Expression<Func<T,bool>> whereLambda,bool isAsc, Expression<Func<T,OrderByT>> orderByLambda, bool isNoTracking);

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageSize">设置一页有多少条记录</param>
        /// <param name="isNoTracking">是否不跟踪查询（true不跟踪，false跟踪）</param>
        /// <returns></returns>
        IQueryable<T> GetAllByPage(int pageIndex,int pageSize,bool isNoTracking);

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageSize">设置一页有多少条记录</param>
        /// <param name="whereLambda">where查询lambda表达式</param>
        /// <param name="isNoTracking">是否不跟踪查询（true不跟踪，false跟踪）</param>
        /// <returns></returns>
        IQueryable<T> GetAllByPage(int pageIndex, int pageSize, Expression<Func<T,bool>> whereLambda, bool isNoTracking);

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="OrderByT"></typeparam>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageSize">设置一页有多少条记录</param>
        /// <param name="whereLambda">where查询lambda表达式</param>
        /// <param name="isAsc">是否按Asc排序</param>
        /// <param name="orderByLambda"></param>
        /// <param name="isNoTracking">是否不跟踪查询（true不跟踪，false跟踪）</param>
        /// <returns></returns>
        IQueryable<T> GetAllByPage<OrderByT>(int pageIndex, int pageSize, Expression<Func<T,bool>> whereLambda, bool isAsc, Expression<Func<T,OrderByT>> orderByLambda, bool isNoTracking);

        /// <summary>
        /// 查询一条记录
        /// </summary>
        /// <param name="isNoTracking">是否不跟踪查询（true不跟踪，false跟踪）</param>
        /// <returns></returns>
        T FirstOrDefault(bool isNoTracking);

        /// <summary>
        /// 查询一条记录
        /// </summary>
        /// <param name="whereLambda">where查询lambda表达式</param>
        /// <param name="isNoTracking">是否不跟踪查询（true不跟踪，false跟踪）</param>
        /// <returns></returns>
        T FirstOrDefault(Expression<Func<T,bool>> whereLambda,bool isNoTracking);

        /// <summary>
        /// 按主键查询一条记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T Find(int id);

        /// <summary>
        /// 统计有多少条记录
        /// </summary>
        /// <returns></returns>
        int Count();

        /// <summary>
        /// 按where条件统计有多少条记录
        /// </summary>
        /// <param name="whereLambda">where查询lambda表达式</param>
        /// <returns></returns>
        int Count(Expression<Func<T,bool>> whereLambda);


        /// <summary>
        /// select top N
        /// </summary>
        /// <param name="num">要返回TOP记录的条数</param>
        /// <param name="isNoTracking">是否不跟踪查询（true不跟踪，false跟踪）</param>
        /// <returns></returns>
        IQueryable<T> Top(int num,bool isNoTracking);

        /// <summary>
        /// select top N
        /// </summary>
        /// <param name="num">要返回TOP记录的条数</param>
        /// <param name="whereLambda">where查询lambda表达式</param>
        /// <param name="isNoTracking">是否不跟踪查询（true不跟踪，false跟踪）</param>
        /// <returns></returns>
        IQueryable<T> Top(int num,Expression<Func<T,bool>> whereLambda, bool isNoTracking);

        /// <summary>
        /// select top N
        /// </summary>
        /// <typeparam name="OrderByT">orderbyType</typeparam>
        /// <param name="num">要返回TOP记录的条数</param>
        /// <param name="whereLambda">where查询lambda表达式</param>
        /// <param name="isAsc">是否按Asc排序</param>
        /// <param name="orderByLambda"></param>
        /// <param name="isNoTracking">是否不跟踪查询（true不跟踪，false跟踪）</param>
        /// <returns></returns>
        IQueryable<T> Top<OrderByT>(int num,Expression<Func<T,bool>> whereLambda,bool isAsc, Expression<Func<T,OrderByT>> orderByLambda, bool isNoTracking);

        /// <summary>
        /// 保存
        /// </summary>
        /// <returns></returns>
        bool SaveChanges();
        /// <summary>
        /// 查询是否存实体
        /// </summary>
        /// <param name="whereLambda">where查询lambda表达式</param>
        /// <returns></returns>
        bool Any(Expression<Func<T, bool>> whereLambda);
    }
}
