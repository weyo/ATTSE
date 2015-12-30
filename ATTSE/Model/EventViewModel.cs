/**
* Namespace: ATTSE.Model
*
* Function : N/A
* Class    : EventViewModel
*
* Verion  Date                 Author  Content
* ------------------------------------------------------------
* V0.01   2015/12/22 14:22:38  Yohn    Initial version
*/
using System.Collections.ObjectModel;

namespace ATTSE.Model
{
    class EventViewModel
    {
        #region Members
        ObservableCollection<ScreenEvent> events = new ObservableCollection<ScreenEvent>();
        #endregion

        #region Properties
        public ObservableCollection<ScreenEvent> Events
        {
            get
            {
                return events;
            }
            set
            {
                events = value;
            }
        }
        #endregion
    }
}
