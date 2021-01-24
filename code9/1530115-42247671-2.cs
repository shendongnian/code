    public class LanguageViewModel : INotifyPropertyChanged
    {
        private LanguageModel _selectedItem;
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private int currentIndex = 1;
        public LanguageViewModel()
        {
            Items = new ObservableCollection<LanguageModel>();
            Items.Add(new LanguageModel { Language = "fr-FR" });
            Items.Add(new LanguageModel { Language = "en-GB" });
            Items.Add(new LanguageModel { Language = "en-US" });
            Items.Add(new LanguageModel { Language = "de-DE" });
            Items.Add(new LanguageModel { Language = "es-ES" });
            SelectedItem = Items[currentIndex];
        }
        public ObservableCollection<LanguageModel> Items { get; set; }
        public LanguageModel SelectedItem
        {
            get { return _selectedItem; }
            set { _selectedItem = value; OnPropertyChanged(); }
        }
        public void NextItemFromViewModel()
        {
            SelectedItem = Items[++currentIndex];
        }
    }
