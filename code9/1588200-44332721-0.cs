    public void Run()
    {
        this.running = true;
        do
        {
            DateTime nextDeadlineUtc;
            ScheduledTask nextTask;
            bool deadlineExpired;
            nextDeadlineUtc = ComputeNextDeadline( out nextTask );
            deadlineExpired = WaitForDeadline( nextDeadlineUtc );
            if( deadlineExpired )
            {
                // We hit the deadline. Execute the task and move on.
                nextTask.Execute();
            }
            else
            {
                // We were woken up before the deadline expired. That means either we're shutting
                // down, or we need to recompute our next deadline because the schedule changed.
                // To deal with this, just do nothing. We'll loop back around and either find out
                // we're being asked to stop, or we'll recompute the next deadline.
            }
        }
        while( this.running );
    }
    /// <summary>
    /// Sleeps until the deadline has expired.
    /// </summary>
    /// <param name="nextDeadlineUtc">The next deadline, in UTC</param>
    /// <returns>
    /// True if the deadline has elapsed; false if the scheduler should re-examine its next deadline.
    /// </returns>
    private bool WaitForDeadline( DateTime nextDeadlineUtc )
    {
        TimeSpan wait;
        bool incompleteDeadline;
        bool acquired;
        wait = ComputeSleepTime( nextDeadlineUtc, out incompleteDeadline );
        acquired = this.waiter.Wait( wait );
        if( acquired || incompleteDeadline )
        {
            // Either:
            // - We were manually woken up early by someone releasing the semaphore.
            // - The timeout expired, but that's because we didn't wait for the complete time.
            // 
            // Either way, the deadline didn't expire.
            return false;
        }
        else
        {
            // The deadline occurred. 
            return true;
        }
    }
    private TimeSpan ComputeSleepTime( DateTime nextDeadlineUtc, out bool incompleteDeadline )
    {
        TimeSpan totalRemaining = nextDeadlineUtc - DateTime.UtcNow;
        if( totalRemaining.Ticks < 0 )
        {
            // Were already out of time.
            incompleteDeadline = false;
            return TimeSpan.FromTicks( 0 );
        }
        else if( totalRemaining.TotalHours <= 1.01 )
        {
            // Just sleep the whole of the remainder.
            incompleteDeadline = false;
            return totalRemaining;
        }
        else
        {
            // More than one hour to sleep. Sleep for at most one hour, but tell the sleeper that
            // there's still more time left.
            incompleteDeadline = true;
            return TimeSpan.FromHours( 1.0 );
        }
    }
