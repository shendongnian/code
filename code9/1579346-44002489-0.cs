    using System;
    using System.Linq;
    using System.ServiceProcess;
    
    namespace Revenue.Common.Utility
    {
        public class WindowsServices
        {
            private string _ErrorMessage;
            public string ErrorMessage { get { return _ErrorMessage; } }
            /// <summary>
            /// Stop a Windows service service name
            /// </summary>
            /// <param name="ServiceName"></param>
            /// <remarks>
            /// A service does not stop instantly, so WaitForStatus method
            /// is used to 'wait' until the service has stopped. If the
            /// caller becomes unresponsive then there may be issues with
            /// the service stopping outside of code.
            /// </remarks>
            public void StopService(string ServiceName)
            {
                ServiceController sc = ServiceController.GetServices().FirstOrDefault(s => s.ServiceName == ServiceName);
                if (sc == null)
                    return;
    
                if (sc.Status == ServiceControllerStatus.Running)
                {
                    try
                    {
                        sc.Stop();
                        sc.WaitForStatus(ServiceControllerStatus.Stopped);
                    }
                    catch (InvalidOperationException e)
                    {
                        _ErrorMessage = e.Message;
                    }
                }
            }
            /// <summary>
            /// Start a Windows service by service name
            /// </summary>
            /// <param name="ServiceName"></param>
            public void StartService(string ServiceName)
            {
                ServiceController sc = ServiceController.GetServices().FirstOrDefault(s => s.ServiceName == ServiceName);
                if (sc == null)
                    return;
    
                sc.ServiceName = ServiceName;
                if (sc.Status == ServiceControllerStatus.Stopped)
                {
                    try
                    {
                        sc.Start();
                        sc.WaitForStatus(ServiceControllerStatus.Running);
                    }
                    catch (InvalidOperationException)
                    {
                        _ErrorMessage = e.Message;
                    }
                }
            }
        }
    }
