using System;
using System.Windows;
using System.Windows.Input;
using System.Text.RegularExpressions;
using ATTSE.Model;
using System.Collections.Generic;
using System.Threading;
using ATTSE.Model.Utility;

namespace ATTSE
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private EventViewModel model;
        private bool stopFlag;

        public MainWindow()
        {
            InitializeComponent();
            model = (EventViewModel)this.DataContext;
        }

        private void start_Click(object sender, RoutedEventArgs e)
        {
            int roundCount = Convert.ToInt32(round_count.Text);
            if (roundCount < 1)
            {
                MessageBox.Show("请设置循环次数！");
                return;
            }
            else if (model.Events.Count < 1)
            {
                MessageBox.Show("事件列表为空！");
                return;
            }

            for (int i = 0; i < roundCount; i++)
            {
                foreach (ScreenEvent se in model.Events)
                {
                    Point point = se.Pt;
                    MouseOperationUtility.SetMousePosition(point);

                    for (int j = 0; j < se.Round; j++)
                    {
                        if (se.ScreenEventType == EventType.MOUSE_EVENT)
                        {
                            MouseOperationUtility.HandleMouseEvent(point, se.ScreenActionType);
                        }
                        else if (se.ScreenEventType == EventType.KEYBOADR_EVENT)
                        {
                            // TO-DO
                        }

                        Thread.Sleep(se.Timeout);
                    }
                }
            }
        }

        //private void stop_Click(object sender, RoutedEventArgs e)
        //{
        //    // TO-DO
        //}

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            int deleteIndex = lstEvents.SelectedIndex;
            if (deleteIndex < 0)
            {
                return;
            }

            IList<ScreenEvent> list = model.Events;
            list.RemoveAt(deleteIndex);
            int count = list.Count;
            for (int i = deleteIndex; i < count; i++)
            {
                list[i].ID -= 1;
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (((e.KeyboardDevice.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
                && (e.Key == Key.T))
            {
                int x;
                int y;
                CursorUtility.GetCursorPosition(out x, out y);
                model.Events.Add(new ScreenEvent(model.Events.Count + 1,
                    EventType.MOUSE_EVENT, ActionType.LEFT_MOUSE_CLICK, 
                    1000, 1, new Point(x, y)));
            }
        }

        /// <summary>
        /// 文本框只接受数字参数
        /// </summary>
        /// <param name="text">输入参数</param>
        /// <returns>是否是允许的参数</returns>
        private static bool IsTextAllowed(string text)
        {
            Regex regex = new Regex("[^0-9]+");
            return !(regex.IsMatch(text));
        }
        
        private void NumberTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }

        private void NumberTextBox_Pasting(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(String)))
            {
                String text = (String)e.DataObject.GetData(typeof(String));
                if (!IsTextAllowed(text))
                {
                    e.CancelCommand();
                }
            }
            else
            {
                e.CancelCommand();
            }
        }
    }
}
