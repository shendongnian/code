    public class LocalizationViewModel : INotifyPropertyChanged
    {
        public string Title
        {
            get
            {
                return LocalizationValues.Title;
            }
        }
        public string Description
        {
            get
            {
                return LocalizationValues.Description;
            }
        }
        public void SetLanguage(string language)
        {
            var culture = new CultureInfo(language);
            Thread.CurrentThread.CurrentUICulture = culture;
            // This is important, 
            // By raising PropertyChanged you notify Form to update bounded controls
            // Passing empty string as propertyName
            // will indicate that all properties of viewmodel have changed
            NotifyPropertyChanged(string.Empty);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
