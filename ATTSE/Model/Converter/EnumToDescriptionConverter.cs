/**
* Namespace: ATTSE.Model.Converter
*
* Function : N/A
* Class    : EnumToDescriptionConverter
*
* Verion  Date                 Author  Content
* ------------------------------------------------------------
* V0.01   2015/12/28 9:44:58  Yohn    Initial version
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Windows.Data;

namespace ATTSE.Model.Converter
{
    /// <summary>
    /// 枚举类型转换器
    /// </summary>
    public abstract class EnumToDescriptionConverter : IValueConverter
    {
        protected static Dictionary<Type, Dictionary<object, string>> enumsDic 
            = new Dictionary<Type, Dictionary<object, string>>();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ConvertToDescription(value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        protected abstract object ConvertToDescription(object enumObj);

        protected bool GetDescription(FieldInfo field, ref string description)
        {
            DescriptionAttribute[] a = (DescriptionAttribute[])field.GetCustomAttributes(
                typeof(DescriptionAttribute), false);
            if (a != null && a.Length > 0)
            {
                description = a[0].Description;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Dictionary 初始化，在第一次转换枚举类型时解析转换该类型的所有枚举值存入 Dictionary
        /// </summary>
        /// <param name="enumObj">待转换的枚举类型</param>
        protected void initializeDic(object enumObj)
        {
            Type type = enumObj.GetType();
            if (!enumsDic.ContainsKey(type))
            {
                Dictionary<object, string> dic = new Dictionary<object, string>();
                foreach (var field in type.GetFields().Where(f => f.IsLiteral))
                {
                    string description = enumObj.ToString();
                    GetDescription(field, ref description);
                    dic.Add(field.GetValue(type), description);
                }
                enumsDic.Add(type, dic);
            }
        }
    }    
}
