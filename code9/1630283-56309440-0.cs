    public struct EasyTimer
    {
        /// <summary>
        /// Gets a value indicating whether or not the time interval has elapsed.
        /// </summary>
        /// <remarks>
        /// If the time interval has elapsed, the timer is reset to check the next time interval.
        /// </remarks>
        public bool HasElapsed
        {
            get
            {
                var nowTicks = DateTime.UtcNow.Ticks;
                if (nowTicks - this.startTicks < this.intervalTicks) { return false; }
                this.startTicks = DateTime.UtcNow.Ticks;
                return true;
            }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="EasyTimer"/> structure with the
        /// time interval to check.
        /// </summary>
        /// <param name="intervalInMilliseconds">
        /// The time interval to check in milliseconds.
        /// </param>
        public EasyTimer(int intervalInMilliseconds)
        {
            this.intervalTicks = TimeSpan.FromMilliseconds(intervalInMilliseconds).Ticks;
            this.startTicks    = DateTime.UtcNow.Ticks;
        }
        private          long startTicks;
        private readonly long intervalTicks;
    }
