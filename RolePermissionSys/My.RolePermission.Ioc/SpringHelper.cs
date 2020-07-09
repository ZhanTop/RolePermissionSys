using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spring.Context;
using Spring.Context.Support;

namespace My.RolePermission.Ioc
{
    /// <summary>
    /// 这里选用的Ioc框架是Spring.Net
    /// </summary>
    public class SpringHelper
    {
        #region Spring容器上下文+IApplicationContext SpringContext
        /// <summary>
        /// Spring 容器上下文
        /// </summary>
        private static IApplicationContext SpringContext
        {
            get
            {
                return ContextRegistry.GetContext();
            }
        }
        #endregion

        #region 获取配置文件配置的对象 + T GetObject<T>(string objName) where T :class
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objName"></param>
        /// <returns></returns>
        public static T GetObject<T>(string objName) where T : class 
        {
            return (T)SpringContext.GetObject(objName);
        }
        #endregion
    }
}
