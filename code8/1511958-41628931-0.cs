        public VM()
        {
            items = new ObservableCollection<string>();
            
            Items.Insert(0, "The time now is " + DateTime.Now.ToShortTimeString());
            var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(60) };
            timer.Tick += (s, e) =>
            {
                Items.Insert(0,"The time now is " + DateTime.Now.ToShortTimeString());
            };
            timer.Start();
        }
       
        private ObservableCollection<string> items;
        public ObservableCollection<string> Items
        {
            get { return items; }
           
        }
