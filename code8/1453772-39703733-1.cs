           private void LoadPoll()
            {
                for (int i = 1; i <= 3; i++)
                {
                    Polls.Add("Poll" + i.ToString());
                }
            }
    
            private ObservableCollection<string> _Polls = new ObservableCollection<string>();
            public ObservableCollection<string> Polls
            {
                get { return _Polls; }
                set
                {
                    _Polls = value;
                }
            }     
   
   
            
