    private string _test;
        public string Test
        {
            get { return _test; }
            set
            {
               Task.Run(() =>
               {
                   //do stuff
               });
                _test = value;
            }
        }
