using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace My.RolePermission.IDAL
{
    /// <summary>
    /// 仓储泛型接口
    /// </summary>
    public interface IBaseRepository<T> where T:class,new()
    {
        /// <summary>
        /// 条件查询
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        IQueryable<T> LoadEntities(Expression<Func<T,bool>> whereLambda);

        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="model"></typeparam>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalCount"></param>
        /// <param name="whereLambda"></param>
        /// <param name="orderby"></param>
        /// <param name="isAsc"></param>
        /// <returns></returns> 
        IQueryable<T> LoadPageEntities<model>(int pageIndex,int pageSize,out int totalCount,Expression<Func<T,bool>> whereLambda,string orderby,bool?isAsc);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool DeleteEntity(T entity);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool EditEntity(T entity);

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        T AddEntity(T entity);

        /// <summary>
        /// 查询所有
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        IQueryable<T> LoadEntitiesAll(string entity);
    }
}
