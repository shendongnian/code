    class Data : INotifyPropertyChanged
    {
        public decimal StockPrice {get;set;} // ToDo: Call notify property changed
    }
    . . .
    ObservableCollection<MyData> Data;
    . . .
    foreach (var d in Data)
    {
        d.StockPrice = Rnd.Next(...);
    }
