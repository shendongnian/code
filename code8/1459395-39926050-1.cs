    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Data;
    using System.Windows.Input;
    using System.Windows.Threading;
    class VM
        {
            Dispatcher _dispatcher = Dispatcher.CurrentDispatcher;
            //Time consuming operation
            private void LongTask()
            {
                Thread.Sleep(5000);
                //in here if you need to send something to the UI thread like an event use it like so:
                _dispatcher.Invoke(new Action(() =>
                {
                    //some code here to invoke an event
                    if (ComponentsLoaded != null)
                        ComponentsLoaded(this, new EventArgs { });
                }));
            }
    
            private ICommand _command;
            //This is the command to be used instead of click event handler
            public ICommand Command
            {
                get { return _command; }
                private set { _command = value; }
            }
            //method associated with ICommand
            void commandMethod(object parameter)
            {
                Busy = true;
                ThreadPool.QueueUserWorkItem(new WaitCallback(multiThreadTask));
                Busy = false;
            }
            //the task to be started on another thread
            void multiThreadTask(object parameter)
            {
                LongTask();
            }
    
            public event EventHandler ComponentsLoaded;
        }  
