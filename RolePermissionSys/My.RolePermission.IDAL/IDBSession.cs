using System;
using System.Collections.Generic;
using System.Linq; 
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace My.RolePermission.IDAL
{
    /// <summary>
    /// partial:部分接口（允许一个类、接口、结构分成几个部分，分别实现在几个不同的.cs文件中）
    /// </summary>
    public partial interface IDBSession
    {
        DbContext Db { get; }
        bool SaveChanges();
        int ExcuteSql(string sql,params System.Data.SqlClient.SqlParameter[] pars);
        List<T> ExecuteSelectQuery<T>(string sql,params System.Data.SqlClient.SqlParameter[] pars);
    }
}
