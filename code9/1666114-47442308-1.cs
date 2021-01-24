    public class MainViewModel
    {
        public MainViewModel()
        {
            RemoveRowItemCommand = new DelegateCommand<RowItem>(RemoveRowItem);
            AddRowItemCommand = new DelegateCommand<object>(AddRowItem);
        }
        public ObservableCollection<RowItem> RowItems { get; } = new ObservableCollection<RowItem>();
        public ICommand RemoveRowItemCommand { get; private set; }
        public ICommand AddRowItemCommand { get; private set; }
        public void RemoveRowItem(RowItem rowItem)
        {
            RowItems.Remove(rowItem);
        }
        private int _nextRowItemID = 0;
        public void AddRowItem(object unused)
        {
            RowItems.Add(new RowItem { Text = $"Row {++_nextRowItemID}" });
        }
    }
    public class DelegateCommand<TParam> : ICommand
    {
        public DelegateCommand(Action<TParam> exec)
        {
            _execute = exec;
        }
        public event EventHandler CanExecuteChanged;
        private Action<TParam> _execute;
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            _execute?.Invoke(parameter == null ? default(TParam) : (TParam)parameter);
        }
    }
    public class RowItem
    {
        public String Text { get; set; }
    }
