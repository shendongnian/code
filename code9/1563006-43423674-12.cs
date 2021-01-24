    public class DataCS4 : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        // Represent an Observable
        private int firstNumber;
        public int FirstNumber
        {
            get { return firstNumber; }
            set
            {
                if (value == firstNumber)
                    return;
                this.firstNumber = value;
                OnPropertyChanged("FirstNumber");
                OnPropertyChanged("Sum");
            }
        }
        // Represent an Observable
        private int secondNumber;
        public int SecondNumber
        {
            get { return secondNumber; }
            set
            {
                if (value == secondNumber)
                    return;
                this.secondNumber = value;
                OnPropertyChanged("SecondNumber");
                OnPropertyChanged("Sum");
            }
        }
        // Represent Computed
        public int Sum { get { return FirstNumber + SecondNumber; } }
    }
