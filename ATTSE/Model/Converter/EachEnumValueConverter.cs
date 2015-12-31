/**
* Namespace: ATTSE.Model.Converter
*
* Function : N/A
* Class    : EachEnumValueConverter
*
* Verion  Date                 Author  Content
* ------------------------------------------------------------
* V0.01   2015/12/28 11:42:38  Yohn    Initial version
*/

namespace ATTSE.Model.Converter
{
    /// <summary>
    /// 基本枚举-字符串转换器
    /// </summary>
    public class EachEnumValueConverter : EnumToDescriptionConverter
    {
        protected override object ConvertToDescription(object enumObj)
        {
            initializeDic(enumObj);

            return enumsDic[enumObj.GetType()][enumObj];
        }
    }
}
