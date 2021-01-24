    using System;
    using System.Timers;
    namespace ManageScreenSaver.MediaElementWpf
    {
        public class ScreenSaverManager
        {
            private static ScreenSaverManager _Manager;
            public static ScreenSaverManager Instance
            {
                get
                {
                    if (_Manager != null)
                        return _Manager;
                    _Manager = new ScreenSaverManager();
                    return _Manager;
                }
            }
            private TimeSpan _ScreenSaverTimeout;
            private bool _IsScreenSaverSecure;
            private Timer _Timer;
            protected ScreenSaverManager()
            {
                _ScreenSaverTimeout = NativeMethods.ScreenSaverTimeout;
                _IsScreenSaverSecure = NativeMethods.IsScreenSaverSecure;
                _Timer = new Timer(_ScreenSaverTimeout.TotalMilliseconds/2);
                _Timer.AutoReset = false;
                _Timer.Elapsed += Timer_Elapsed;
                _Timer.Start();
            }
            private void Timer_Elapsed(object sender, ElapsedEventArgs e)
            {
                var lastInput = NativeMethods.GetLastUserInputTimeInterval();
                MainWindow.Console.WriteLine($"Last user input interval: {lastInput}");
                if (lastInput >= _ScreenSaverTimeout)
                {
                    StartScreenSaver();
                }
                else
                {
                    _Timer.Interval = _ScreenSaverTimeout.Subtract(lastInput).TotalMilliseconds + 100;
                    _Timer.Start();
                }
            }
            private void StartScreenSaver()
            {
                if (_IsScreenSaverSecure)
                {
                    NativeMethods.LockWorkStationSession();
                }
                else
                {
                    var result = NativeMethods.SendMessage((IntPtr) 0xffff, (uint) WindowMessage.WM_SYSCOMMAND, (uint) WmSysCommandParam.ScSCREENSAVE, 0);
                }
            }
        }
    }
