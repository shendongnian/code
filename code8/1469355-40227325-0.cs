    class test
    {
        private MyTimer _timer; // Removed field initializer.
        // Added constructor.
        internal test()
        {
            // Moved initialization of _timer into constructor.
            _timer = new MyTimer(TimerCallBack, 1, 0, null);
        }
        void TimerCallBack(object state)
        {
            //Do something
        }
    }
