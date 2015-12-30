/**
* Namespace: ATTSE.Model.Utility
*
* Function : N/A
* Class    : CursorUtility
*
* Verion  Date                 Author  Content
* ------------------------------------------------------------
* V0.01   2015/12/29 16:31:50  Yohn    Initial version
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace ATTSE.Model.Utility
{
    public class CursorUtility
    {
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool GetCursorPos(ref Win32Point pt);

        [StructLayout(LayoutKind.Sequential)]
        internal struct Win32Point
        {
            public Int32 X;
            public Int32 Y;
        };

        internal static void GetCursorPosition(out int x, out int y)
        {
            Win32Point w32Mouse = new Win32Point();
            GetCursorPos(ref w32Mouse);
            x = w32Mouse.X;
            y = w32Mouse.Y;
        }
    }
}
