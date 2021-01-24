    public class MainViewModel : ObservableObject
    {
        public MainViewModel()
        {
            var list = new List<MatrixType>
            {
                new MatrixType {Height = "233", Name = "A", Width = "133"},
                new MatrixType {Height = "333", Name = "B", Width = "233"},
                new MatrixType {Height = "433", Name = "C", Width = "333"}
            };
            Items = new ObservableCollection<MatrixType>(list);
        }
        private MatrixType _selectedItem;
        public MatrixType SelectedItem
        {
            get => _selectedItem;
            set { _selectedItem = value; RaisePropertyChanged(); }
        }
        public ObservableCollection<MatrixType> Items { get; set; }
    }
