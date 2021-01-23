    public class StringModel : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;
    
        private readonly ObservableCollection<string> _collection = new ObservableCollection<string>();
        private readonly ObservableCollection<string> _suggCollection = new ObservableCollection<string>();
        private readonly ObservableCollection<string> _primaryCollection = new ObservableCollection<string>();
    
        public ObservableCollection<string> Collection => this._collection;
    
        public ObservableCollection<string> SuggCollection => this._suggCollection;
    
        public StringModel() {
          this._primaryCollection.Add("John");
          this._primaryCollection.Add("Jack");
          this._primaryCollection.Add("James");
          this._primaryCollection.Add("Emma");
          this._primaryCollection.Add("Peter");
        }
    
        public ICommand AutoBTextCommand {
          get {
            return new RelayCommand(obj => {
              this.Search(obj as string);
            });
          }
        }
    
        private void Search(string str) {
          this.SuggCollection.Clear();
          foreach (var result in this._primaryCollection.Where(m => m.ToLowerInvariant().Contains(str.ToLowerInvariant())).Select(m => m)) {
            this.SuggCollection.Add(result);
          }
    
        }
    
      }
