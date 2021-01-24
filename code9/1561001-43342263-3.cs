    namespace WPFGridLoadingRow
    {
        [ImplementPropertyChanged]
        public class VM: ViewModelBase
        {
            public ObservableCollection<MyLong> ItemsSource { get; set; }
            public VM()
            {
                ItemsSource = new ObservableCollection<MyLong>();
                AddRowCommand = new DelegateCommand(AddRow);
                RowLoadedCommand = new DelegateCommand<object>(RowLoaded);
            }
            public void RowLoaded(object currentRow)
            {
                // currentRow now is the same as e.Row.Item
            }
            public DelegateCommand AddRowCommand { get; set; }
            private void AddRow()
            {
                ItemsSource.Add(new MyLong { Value = 333L });
            }
            public DelegateCommand<object> RowLoadedCommand { get; set; }
        }
        [ImplementPropertyChanged]
        public class MyLong
        {
            public long Value { get; set; }
        }
    }
