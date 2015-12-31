/**
* Namespace: ATTSE.Model.Converter
*
* Function : N/A
* Class    : EnumValuesConverter
*
* Verion  Date                 Author  Content
* ------------------------------------------------------------
* V0.01   2015/12/28 13:53:31  Yohn    Initial version
*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ATTSE.Model.Converter
{
    /// <summary>
    /// 批量枚举类型转换器
    /// </summary>
    public class EnumValuesConverter : EnumToDescriptionConverter
    {
        /// <summary>
        /// 将枚举类型值转换为列表
        /// </summary>
        /// <param name="enumObjs">待转换的枚举类型</param>
        /// <returns>转换后的列表（List）</returns>
        protected override object ConvertToDescription(object enumObjs)
        {
            try
            {
                object[] objs = ((IEnumerable)enumObjs).Cast<object>().ToArray();
                if (objs.Length > 0)
                {
                    object enumObj = objs[0];
                    initializeDic(enumObj);
                    Dictionary<object, string> dict = enumsDic[enumObj.GetType()];
                    List<object> result = new List<object>();
                    foreach (string s in dict.Values)
                    {
                        result.Add(s);
                    }
                    return result;
                }
                else
                {
                    throw new NotSupportedException("枚举类型值域为空，请检查！");
                }
            }
            catch(Exception e)
            {
                throw new NotSupportedException("枚举类型错误，请检查！", e);
            }
        }
    }
}
