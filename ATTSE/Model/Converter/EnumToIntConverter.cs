/**
* Namespace: ATTSE.Model.Converter
*
* Function : N/A
* Class    : EnumToIntConverter
*
* Verion  Date                 Author  Content
* ------------------------------------------------------------
* V0.01   2015/12/28 15:08:15  Yohn    Initial version
*/
using System;
using System.Globalization;
using System.Windows.Data;

namespace ATTSE.Model.Converter
{
    /// <summary>
    /// 枚举类型与整型值互相转换（便于 SelectedItem 操作）
    /// </summary>
    public class EnumToIntConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (int)value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Enum.Parse(targetType, value.ToString(), true);
        }
    }
}
