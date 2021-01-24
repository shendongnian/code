    public class LanguageModel : INotifyPropertyChanged
    {
        private string _language;
        public string Language
        {
            get { return _language; }
            set
            {
                _language = value;
                OnPropertyChanged();
            }
        }
        protected bool Equals(LanguageModel other)
        {
            return string.Equals(Language, other.Language);
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((LanguageModel)obj);
        }
        public override int GetHashCode()
        {
            return (Language != null ? Language.GetHashCode() : 0);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
