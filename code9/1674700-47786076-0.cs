    public class ViewModel
    {
        readonly ObservableCollection<KeyValuePair<string, string>> _availableStocks;
        public ObservableCollection<KeyValuePair<string, string>> AvailableStocks { get; set; }
        public bool IsExecuting {get; set; }
        public ViewModel()
        {
            _availableStocks = new ObservableCollection<KeyValuePair<string, string>>();
            IsExecuting = true;
            TaskFactory.StartNew(() =>
            {
                var result = StockService.GetAvailableStocks(User);
                foreach (var stock in result)
                    AvailableStocks.Add(stock);
                IsExecuting = false;
            }
        }
    }
