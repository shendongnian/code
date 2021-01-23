    public sealed class UserActivityMonitor
    {
        /// <summary>Default constructor.</summary>
        public UserActivityMonitor()
        {
            _lastInputInfo.CbSize = Marshal.SizeOf(_lastInputInfo);
        }
        /// <summary>Determines the time of the last user activity (any mouse activity or key press).</summary>
        /// <returns>The time of the last user activity.</returns>
        public DateTime LastActivity => DateTime.Now - this.InactivityPeriod;
        /// <summary>The amount of time for which the user has been inactive (no mouse activity or key press).</summary>
        public TimeSpan InactivityPeriod
        {
            get
            {
                lock (_locker)
                {
                    GetLastInputInfo(ref _lastInputInfo);
                    uint elapsedMilliseconds = (uint) Environment.TickCount - _lastInputInfo.DwTime;
                    elapsedMilliseconds = Math.Min(elapsedMilliseconds, int.MaxValue);
                    return TimeSpan.FromMilliseconds(elapsedMilliseconds);
                }
            }
        }
        public async Task WaitForInactivity(TimeSpan inactivityThreshold, TimeSpan checkInterval, CancellationToken cancel)
        {
            while (true)
            {
                await Task.Delay(checkInterval, cancel);
                if (InactivityPeriod > inactivityThreshold)
                    return;
            }
        }
        // ReSharper disable UnaccessedField.Local
        /// <summary>Struct used by Windows API function GetLastInputInfo()</summary>
        struct LastInputInfo
        {
            #pragma warning disable 649
            public int  CbSize;
            public uint DwTime;
            #pragma warning restore 649
        }
        // ReSharper restore UnaccessedField.Local
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetLastInputInfo(ref LastInputInfo plii);
        LastInputInfo _lastInputInfo;
        readonly object _locker = new object();
    }
