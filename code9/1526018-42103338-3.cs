    namespace MyWpfApp {
        public class MainWindowViewModel : INotifyPropertyChanged {
    
            private void AddNewEntry() {
                TextEntryItems.Add(new TextEntryViewModel("NewItem"));
            }
    
            private ObservableCollection<TextEntryViewModel> textEntryItems;
            public ObservableCollection<TextEntryViewModel> TextEntryItems { get { return textEntryItems; } set { textEntryItems = value; FirePropertyChanged(); } }
    
            public ICommand AddNewEntryCommand { get { new RelayCommand(AddNewEntry)} }
        }
    
        public class TextEntryViewModel : INotifyPropertyChanged {
    
            public TextEntryViewModel(string label) {
                Label = label;
            }
    
            private string label;
            public string Label { get { return label; } set { label = value; FirePropertyChanged(); } }
    
            private string data;
            public string Data { get { return data; } set { data = value; FirePropertyChanged(); } }        
        }
        
    }
