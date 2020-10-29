using Autofac.Core;
using System;
using System.Reflection;

namespace AutofacLifeTimeScopeDemo.Main.Model
{
    /// <summary>
    /// 依赖注入-属性注入特性
    /// </summary>
    public class Autowired : Attribute
    {

    }
    /// <summary>
    /// 依赖注入-属性注入华律自定义选择器
    /// </summary>
    public class HuaLvPropertySelector : IPropertySelector
    {
        ///  <summary>
        /// 是否注入属性
        /// </summary>
        /// <param name="propertyInfo"></param>
        /// <param name="instance"></param>
        /// <returns></returns>
        public bool InjectProperty(PropertyInfo propertyInfo, object instance)
        {
            if (propertyInfo.GetCustomAttribute<Autowired>(false) == null)
            {
                return false;
            }
            return true;
        }
    }
}
