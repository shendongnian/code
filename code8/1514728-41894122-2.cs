    using System;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Automation;
    using System.Windows.Interop;
    using System.Threading;
    namespace WpfApplication1
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
            private void Window_Loaded(object sender, RoutedEventArgs routedEventArgs)
            {
                IntPtr windowHandle = new WindowInteropHelper(this).Handle;
                Task.Run(() =>
                {
                    var element = AutomationElement.FromHandle(windowHandle);
                    Automation.AddAutomationEventHandler(InvokePattern.InvokedEvent, element, TreeScope.Descendants,
                        (s, a) =>
                        {
                            var ele = s as AutomationElement;
                            var invokingthread = Thread.CurrentThread;
                            Debug.WriteLine($"Invoked on {invokingthread.ManagedThreadId} for {ele}, event # {a.EventId.Id}");
                            /* detect if this is the UI thread or not,
                             * reference: http://stackoverflow.com/a/14280425/1132334 */
                            if (System.Windows.Threading.Dispatcher.FromThread(invokingthread) == null)
                            {
                                Debug.WriteLine("2nd: this is the event we would be waiting for");
                            }
                            else
                            {
                                Debug.WriteLine("1st: this is the event raised on the UI thread");
                            }
                        });
                });
            }
            private void button_Click(object sender, RoutedEventArgs e)
            {
                Debug.WriteLine("Clicked!");
            }
        }
    }
