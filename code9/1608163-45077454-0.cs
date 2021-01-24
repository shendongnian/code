    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Threading;
    namespace VM
    {
        public class TestViewModel : BaseViewModel
        {
            private static Dispatcher _dispatcher;
            List<object> ListToDisplay { get; set; }//INPC omitted for brevity
            public TestViewModel()
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback((o) =>
                {
                    var result = getDataFromDatabase();
                    UIThread((p) => ListToDisplay = result);
                }));
            }
            List<object> getDataFromDatabase()
            {
                //your logic here
                return new List<object>();
            }
            static void UIThread(Action<object> a)
            {
                if(_dispatcher == null) _dispatcher = Dispatcher.CurrentDispatcher;
                //this is to make sure that the event is raised on the correct Thread
                _dispatcher.Invoke(a);
            }
        }
    }
