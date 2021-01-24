    public class timeHandler : INotifyPropertyChanged
    {
        private buttonAddNewProcessTimeCommand _btnAddNewProcessTimeCommand;
        public ObservableCollection<timeItem> processTimes { get; set; }
        public ICommand btnAddNewProcessTimeCommand
        {
            get
            {
                return _btnAddNewProcessTimeCommand;
            }
        }
        class buttonAddNewProcessTimeCommand : ICommand
        {
            private timeHandler obj;
            public buttonAddNewProcessTimeCommand(timeHandler _obj)
            {
                obj = _obj;
            }
            public Boolean CanExecute(object parameter)
            {
                return true;
            }
            public void Execute(object parameter)
            {
                obj.addProcessTime();
            }
            public event EventHandler CanExecuteChanged;
        }
        public timeHandler()
        {
            loadProcessTimes();
            _btnAddNewProcessTimeCommand = new buttonAddNewProcessTimeCommand(this);
        }
        public void loadProcessTimes()
        {
            timeItem[] aux = new timeItem[]
            {
            new timeItem { AMPM="AM", hours=12, mins=35 },
            new timeItem { AMPM="PM", hours=2, mins=15 },
            new timeItem { AMPM="PM", hours=5, mins=15 }
            };
            processTimes = new ObservableCollection<timeItem>(aux);
        }
        public void addProcessTime()
        {
            processTimes.Add(new timeItem { AMPM = "AM", hours = 12, mins = 0 });
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs("processTimes"));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
