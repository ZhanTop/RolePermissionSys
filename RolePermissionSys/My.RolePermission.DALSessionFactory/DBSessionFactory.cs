using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using My.RolePermission.IDAL;
using System.Runtime.Remoting.Messaging;
namespace My.RolePermission.DALSessionFactory
{
    /// <summary>
    /// 用于创建线程唯一的DBSession对象
    /// </summary>
    public class DBSessionFactory
    {
        public static IDBSession CreateDBSession()
        {
            IDBSession dbSession = (IDBSession)CallContext.GetData("dbSession");
            if(dbSession==null)
            {
                dbSession = new DBSession();
                CallContext.SetData("dbSession", dbSession);
            }
            return dbSession;
        }
    }
}
