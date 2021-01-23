    public class Translator : INotifyPropertyChanged
    {
        public string this[string text]
        {
            get
            {
                //return translation of "text" for current language settings
            }
        }
        public static Translator Instance { get; } = new Translator();
        public event PropertyChangedEventHandler PropertyChanged;
        public void Invalidate()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Binding.IndexerName));
        }
    }
