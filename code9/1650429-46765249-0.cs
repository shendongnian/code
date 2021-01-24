    public class Variable : INotifyPropertyChanged
    {
        public Variable()
        {
            this.hours = "1";
            this.minutes = "2";
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private string hours;
        private string minutes;
        public string Hours
        {
            get { return this.hours.ToString(); }
            set
            {
                if (this.hours != value)
                { 
                    this.hours = value;
                    this.OnPropertyChanged();
                    this.Minutes = "0";                    
                }
            }
        }
        public string Minutes 
        { 
            get { return this.minutes; }
            private set
            {
                if(this.minutes == value)
                    return;
                this.minutes = value;
                OnPropertyChanged()
            }
        }
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName ));
        }
    }
