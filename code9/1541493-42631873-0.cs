    public ObservableCollection<YourObject> _ocYourObject;
        public ObservableCollection<YourObject> ocYourObject{
            get {
                if (_ocYourObject == null) {
                    _ocYourObject = new ObservableCollection<YourObject>();
                }
                return _ocYourObject;
            }
            set {
                if (_ocYourObject!= value) {
                    _ocYourObject= value;
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(ocYourObject)));
                }
            }
        }
    
