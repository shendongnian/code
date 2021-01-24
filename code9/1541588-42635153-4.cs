    public class Model : INotifyPropertyChanged
    { 
        string _imageFilePath;
        public string ImageFilePath { get { return _imageFilePath; } set { _imageFilePath = value; RaisePropertyChanged("ImageFilePath"); } }
        string _text;
        public string Text { get { return _text; } set { _text = value; RaisePropertyChanged("Text"); } }
        public event PropertyChangedEventHandler PropertyChanged;
        void RaisePropertyChanged(string propname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propname));
        } 
    }
