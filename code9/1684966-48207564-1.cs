    public class MyViewModel : PropertyChangedBase {
    
        private string infoLabel= "something";
        public string InfoLabel1 {
            get {
                return infoLabel;
            }
            set {
                infoLabel = value;
                NotifyOfPropertyChange();
                //Or
                //Set(ref infoLabel, value);
            }
        }
    
        public void ChangeUserControllButton() {
            InfoLabel1 = "Hello world";
        }
    
    }
