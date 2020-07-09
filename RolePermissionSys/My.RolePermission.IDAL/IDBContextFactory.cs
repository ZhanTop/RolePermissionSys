using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.RolePermission.IDAL
{
    /// <summary>
    /// 创建数据库上下文对象
    /// </summary>
    public interface IDBContextFactory
    {
        DbContext CreateDbContext();
    }
}
