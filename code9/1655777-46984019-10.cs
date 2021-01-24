        public void LongRunningMethod()
        {
            OnProgressChanged(0);
            // Do some calculations
            OnProgressChanged(10);
        // More calculations and external calls
            OnProgressChanged(20);
        // etc.
        }
