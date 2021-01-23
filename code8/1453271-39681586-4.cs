    public class ConfigurationItemPropertiesFacade : INotifyPropertyChanged
    {
        private ConfigurationItemProperties _Model;
        
        public string Property1
        {
            get { return _Model.Property1; }
            set
            {
                if(Equals(_Model.Property1, value)) return;
                _Model.Property1 = value;
                RaisePropertyChanged();
            }
        }
    }
