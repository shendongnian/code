    class Example
    {
        Dictionary<int, Timer> timer;
    
        public Example()
        {
            timer = new Dictionary<int, Timer>();
            for(int i = 0; i < 12; ++i)
            {
                int iInScopeOfDelegate = i;
                timer.Add(i, new Timer(5000));
                timer[i].Elapsed += delegate { TimerTickCustom(iLocalToDelegate ); };
            }
        }
        public void Process() // called each cycle
        {
            for(int i = 0; i < 12; ++i)
            {
                timer[i].Start();
            }
        }
        private void TimerTickCustom(int i)
        {
            // The value of i coming in does not match the dictionary key.
        }
    }
