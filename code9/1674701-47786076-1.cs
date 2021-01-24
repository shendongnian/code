    public class ViewModel
    {
        readonly ObservableCollection<KeyValuePair<string, string>> _availableStocks;
        public ObservableCollection<KeyValuePair<string, string>> AvailableStocks 
        {
            get => _availableStocks;
        }
        public bool IsExecuting { get; set; }
        public ViewModel()
        {
            _availableStocks = new ObservableCollection<KeyValuePair<string, string>>();
            IsExecuting = true;
            TaskFactory.StartNew(() =>
            {
                var results = StockService.GetAvailableStocks(User);
                foreach (var stock in results)
                    AvailableStocks.Add(stock);
                IsExecuting = false;
            }
        }
    }
