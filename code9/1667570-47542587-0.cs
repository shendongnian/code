    public class MainPageViewModel : INotifyPropertyChanged
    {
        public ICommand AddNoteIconCommand { get; private set; }
        private SQLiteAsyncConnection _db;
        private ObservableCollection<Note> _notes = new ObservableCollection<Note>();
        public ObservableCollection<Note> Notes            
        {
            get { return _notes; }
            set
            {
                if (_notes == value)
                    return;
                _notes = value;
                OnPropertyChanged();
            }
        }
        
        private INavigation Navigation;
        public event PropertyChangedEventHandler PropertyChanged;
        public MainPageViewModel(INavigation Navigation)
        {
            this.Navigation = Navigation;
            AddNoteIconCommand = new Command(AddNewNote);
            PrepareDatabase();
            
        }
        private async void PrepareDatabase()
        {
            _db = DependencyService.Get<ISQLiteDb>().GetConnection();
            var _databasenotes = await _db.Table<Note>().ToListAsync();
            FillObservable(_databasenotes);
        }
        private async void AddNewNote()
        {
            await Navigation.PushAsync(new NewNotePage());
        }
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private void FillObservable(List<Note> _dbnotes)
        {
            foreach (var note in _dbnotes)
            {
                _notes.Add(note);
            }
        }
    }
