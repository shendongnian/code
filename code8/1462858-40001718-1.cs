    public class LearnViewModel : BaseViewModel
    {
        public ObservableCollection<TodoItem> Items { get; } = new ObservableCollection<TodoItem>();
        private ICommand _addTodoItem;
        public ICommand AddTodoItem => 
            _addTodoItem = _addTodoItem ?? new Command(DoAddTodoItem);
        
        private int _count;
        private void DoAddTodoItem()
        {
            var item = new TodoItem { DisplayName = $"Item {++_count}" };
            // NotifyCollectionChanged must happen on UI thread.
            Device.BeginInvokeOnMainThread (() => {
                 Items.Add(item);
            });
        }
    }
