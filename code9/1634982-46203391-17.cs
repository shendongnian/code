    public class ChromWorker
    {
        private Task _t;
        bool isConsumed = false;
        pathChromosom1 [,];
        string _Key = string.Empty;
        List<Tag> _Tags = new List<Tag>();
        public ChromWorker(/*Data that might be useful in your worker*/)
        {
            pathChromosom1 = inChromosomeArrays;
        }
        
        public bool Running
        {
            get
            {
                
                if (_t == null || _t.IsCompleted ) return false;
                return true;
            }
        }
        public bool Done
        {
            get
            {
                return _t != null && _t.IsCompleted;
            }
        }
        public bool Ready
        {
            get { return _t == null; }
        }
        public void Start()
        {
            _t = new Task(_Run);
            _t.Start();
        }
        private void _Run()
        {
            double tries = 0;
            bool Handled = false;
            while (!Handled && tries < Math.Pow(10, 6))
            {
                //Increase our giveup loop
                tries++;
                try
                {
                    /* your Business logic */
                    Handled = true;
         
                }
                catch (Exception e)
                {
                   
                    Console.WriteLine("Exception: {0} StackTrace: {1}", e.Message, e.StackTrace);
                }
            }
        }
    }
