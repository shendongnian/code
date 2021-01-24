    public class DataCS6 : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        // C# 6.0
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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
                OnPropertyChanged();
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
                OnPropertyChanged();
                OnPropertyChanged("Sum");
            }
        }
        // Represent Computed
        public int Sum => FirstNumber + SecondNumber;
    }
