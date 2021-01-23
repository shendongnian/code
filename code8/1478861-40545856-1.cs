    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var propertyChanged = PropertyChanged;
    
            propertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class ViewModel : ViewModelBase
    {
        private string _selectedItem;
        public List<string> MyComboItemsSource { get; }
    
        public string SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                NotifyPropertyChanged();
            }
        }
    
        public ViewModel()
        {
            MyComboItemsSource = new List<string>();
            MyComboItemsSource.Add("hello");
            MyComboItemsSource.Add("world");
    
            SelectedItem = MyComboItemsSource.First();
        }
    }
