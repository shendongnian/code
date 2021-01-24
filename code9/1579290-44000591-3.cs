    public class TrsFundDocItem : INotifyPropertyChanged
    {
        private readonly Action _updateAction;
        //public double Amount { get; set; }
        private double amount;
        public TrsFundDocItem(Action updateAction)
        {
            _updateAction = updateAction;
        }
        public double Amount
        {
            get { return amount; }
            set
            {
                if (amount == value) return;
                amount = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(Amount)));
                _updateAction();
            }
        }
        public double FCAmount { get; set; }
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
 
