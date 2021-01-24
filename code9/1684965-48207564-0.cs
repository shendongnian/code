    public class MyModel : PropertyChangedBase {
    
        private string infoLabel= "something";
        public string InfoLabel1 {
            get {
                return infoLabel;
            }
            set {
                infoLabel = value;
                NotifyOnPropertyChanged();
            }
        }
    
        public void ChangeUserControllButton()
        {
            InfoLabel1 = "Hello world";
        }
    
    }
