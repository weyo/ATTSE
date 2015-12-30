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
    public class EachEnumValueConverter : EnumToDescriptionConverter
    {
        protected override object ConvertToDescription(object enumObj)
        {
            initializeDic(enumObj);

            return enumsDic[enumObj.GetType()][enumObj];
        }
    }
}
