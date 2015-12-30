/**
* Namespace: ATTSE.Model
*
* Function : N/A
* Class    : ScreenEvent
*
* Verion  Date                 Author  Content
* ------------------------------------------------------------
* V0.01   2015/12/22 10:40:00  Yohn    Initial version
*/
using System.ComponentModel;
using System.Windows;

namespace ATTSE.Model
{
    /// <summary>
    /// 屏幕事件
    /// </summary>
    class ScreenEvent : INotifyPropertyChanged
    {
        #region Fields
        private int id;
        private EventType screenEventType;
        private ActionType screenActionType;
        private int timeout;
        private int round;
        #endregion

        #region Properties
        public int ID
        {
            get { return id; }
            set
            {
                if (value != id)
                {
                    id = value;
                    NotifyPropertyChanged("ID");
                }
            }
        }

        public EventType ScreenEventType
        {
            get { return screenEventType; }
            set
            {
                if (value != screenEventType)
                {
                    screenEventType = value;
                    NotifyPropertyChanged("ScreenEventType");
                }
            }
        }

        public ActionType ScreenActionType
        {
            get { return screenActionType; }
            set
            {
                if (value != screenActionType)
                {
                    screenActionType = value;
                    NotifyPropertyChanged("ScreenActionType");
                }
            }
        }

        public int Timeout
        {
            get { return timeout; }
            set
            {
                if (value != timeout)
                {
                    timeout = value;
                    NotifyPropertyChanged("Timeout");
                }
            }
        }

        public int Round
        {
            get { return round; }
            set
            {
                if (value != round)
                {
                    round = value;
                    NotifyPropertyChanged("Round");
                }
            }
        }

        public Point Pt { get; set; }
        #endregion

        #region Constructors
        public ScreenEvent() : this(0, EventType.MOUSE_EVENT,
            ActionType.LEFT_MOUSE_CLICK, 1000, 1, new Point(0, 0)) { }

        public ScreenEvent(Point pt) : this(0, EventType.MOUSE_EVENT,
            ActionType.LEFT_MOUSE_CLICK, 1000, 1, pt) { }

        public ScreenEvent(int id, EventType et, ActionType at,
            int timeout, int round, Point pt)
        {
            this.id = id;
            ScreenEventType = et;
            ScreenActionType = at;
            Timeout = timeout;
            Round = round;
            Pt = pt;
        }
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Methods
        /// <summary>
        /// 修改事件参数通知接口
        /// </summary>
        /// <param name="info">被通知的参数名称</param>
        private void NotifyPropertyChanged(string info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        #endregion
    }

    /// <summary>
    /// 待响应的事件类型（鼠标事件 / 键盘事件）
    /// </summary>
    public enum EventType
    {
        [Description("鼠标事件")]
        MOUSE_EVENT,
        [Description("键盘事件")]
        KEYBOADR_EVENT,
    }

    /// <summary>
    /// 鼠标动作类型（左键 / 右键 / 单击 / 双击）
    /// </summary>
    public enum ActionType
    {
        [Description("左键单击")]
        LEFT_MOUSE_CLICK,
        [Description("右键单击")]
        RIGHT_MOUSE_CLICK,
        [Description("左键双击")]
        LEFT_MOUSE_DOUBLE_CLICK,
        [Description("右键双击")]
        RIGHT_MOUSE_DOUBLE_CLICK,
        [Description("鼠标移动")]
        MOUSE_MOVE,
    }
}
