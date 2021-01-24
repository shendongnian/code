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
            }
            public DelegateCommand AddRowCommand { get; set; }
            private void AddRow()
            {
                ItemsSource.Add(new MyLong { Value = 333L });
            }
        }
        [ImplementPropertyChanged]
        public class MyLong
        {
            public long Value { get; set; }
        }
    }
