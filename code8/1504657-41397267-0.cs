    public class Receipt : INotifyPropertyChanged
    {
        public string Name { get; }
        public int Quantity { get; private set; }
        public decimal Price { get; }
        public string BillNumber { get; private set; }
        public decimal Total => Price * Quantity;
        public string Info => $"{nameof(Name)}: {Name} || {nameof(Quantity)}: {Quantity} || {nameof(Price)}: {Price:C} || {nameof(Total)}: {Total:C}";
        public Receipt(string name, decimal price, string billNumber)
        {
            Name = name;
            Price = price;
            BillNumber = billNumber;
            Quantity = 1;
        }
        public void AddOne()
        {
            Quantity += 1;
            RaisePropertyChanged(nameof(Info));
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
