    public class Bank : INotifyPropertyChanged
    {
        public Bank(Account account1, Account account2)
        {
            Account1 = account1;
            Account2 = account2;
            Account1.PropertyChanged += PropertyChangedPropagator.Create(nameof(Account.Balance), nameof(Total), RaisePropertyChanged);
            Account2.PropertyChanged += PropertyChangedPropagator.Create(nameof(Account.Balance), nameof(Total), RaisePropertyChanged);
        }
        public Account Account1 { get; }
        public Account Account2 { get; }
        public int Total => Account1.Balance + Account2.Balance;
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        public void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
