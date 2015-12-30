/**
* Namespace: ATTSE.Model.Utility
*
* Function : N/A
* Class    : MouseOperationUtility
*
* Verion  Date                 Author  Content
* ------------------------------------------------------------
* V0.01   2015/12/29 15:52:37  Yohn    Initial version
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;

namespace ATTSE.Model.Utility
{
    public class MouseOperationUtility
    {
        private const int MOUSEEVENT_MOVE = 0x00;
        private const int MOUSEEVENT_LEFTDOWN = 0x02;
        private const int MOUSEEVENT_LEFTUP = 0x04;
        private const int MOUSEEVENT_RIGHTDOWN = 0x08;
        private const int MOUSEEVENT_RIGHTUP = 0x10;
        private const int MOUSEEVENT_LEFT_UP_AND_DOWN = MOUSEEVENT_LEFTDOWN | MOUSEEVENT_LEFTUP;
        private const int MOUSEEVENT_RIGHT_UP_AND_DOWN = MOUSEEVENT_RIGHTDOWN | MOUSEEVENT_RIGHTUP;
        
        private static MouseEvent MOUSE_LEFT_CLICK = new MouseEvent(MOUSEEVENT_LEFT_UP_AND_DOWN, MouseClick);
        private static MouseEvent MOUSE_RIGHT_CLICK = new MouseEvent(MOUSEEVENT_RIGHT_UP_AND_DOWN, MouseClick);
        private static MouseEvent MOUSE_LEFT_DOUBLE_CLICK = new MouseEvent(MOUSEEVENT_LEFT_UP_AND_DOWN, MouseDoubleClick);
        private static MouseEvent MOUSE_RIGHT_DOUBLE_CLICK = new MouseEvent(MOUSEEVENT_RIGHT_UP_AND_DOWN, MouseDoubleClick);
        private static MouseEvent MOUSE_MOVEMENT = new MouseEvent(MOUSEEVENT_MOVE, MouseMove);

        private static Dictionary<ActionType, MouseEvent> actionMap = new Dictionary<ActionType, MouseEvent>();

        static MouseOperationUtility()
        {
            actionMap.Add(ActionType.LEFT_MOUSE_CLICK, MOUSE_LEFT_CLICK);
            actionMap.Add(ActionType.RIGHT_MOUSE_CLICK, MOUSE_RIGHT_CLICK);
            actionMap.Add(ActionType.LEFT_MOUSE_DOUBLE_CLICK, MOUSE_LEFT_DOUBLE_CLICK);
            actionMap.Add(ActionType.RIGHT_MOUSE_DOUBLE_CLICK, MOUSE_RIGHT_DOUBLE_CLICK);
            actionMap.Add(ActionType.MOUSE_MOVE, MOUSE_MOVEMENT);
        }

        public delegate void Click(int mouseEvent, Point point);

        private static void MouseMove(int m, Point p)
        {
            // Do nothing.
        }

        private static void MouseClick(int m, Point p)
        {
            mouse_event(m, (int)p.X, (int)p.Y, 0, 0);
        }

        private static void MouseDoubleClick(int m, Point p)
        {
            MouseClick(m, p);
            MouseClick(m, p);
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(int dwFlags, int dx, int dy, uint cButtons, uint dwExtraInfo);

        [DllImport("user32.dll")]
        static extern bool SetCursorPos(int x, int y);

        internal static void SetMousePosition(Point point)
        {
            SetCursorPos((int)point.X, (int)point.Y);
        }

        internal static void HandleMouseEvent(Point point, ActionType screenActionType)
        {
            MouseEvent me = actionMap[screenActionType];
            Click clicker = me.clicker;
            clicker.Invoke(me.device, point);
        }

        internal struct MouseEvent
        {
            public int device;
            public Click clicker;

            public MouseEvent(int md, Click ck)
            {
                device = md;
                clicker = ck;
            }
        }
    }
}
