    public class foo : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;
        public int bar;
        private void NotifyPropertyChanged(string type) {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(type));
            }
        }
        private void test(){
            bar = 1;
            NotifyPropertyChanged("changed int");
        }
    }
