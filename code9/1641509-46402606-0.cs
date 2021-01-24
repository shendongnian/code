    private async void OnUpdate(object sender, object e)
    {
        this.Price.Value = (await API.GetData(1))[0]["price_eur"];
    }
    class PriceModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _value;
        public string Value
        {
            get { return _value; }
            set
            {
                _value = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Value"));
            }
        }
    }
