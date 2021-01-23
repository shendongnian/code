    public ObservableCollection<MyPath> fileNames { get; set; }
    public class MyPath: ObservableObject  //implement INotifyPropertyChanged
    {
        private string _filepath;        
        public string FilePath
        {
            get { return _filepath; }
            set
            {
                if (value != _filepath)
                {
                    _filepath= value;
                    RaisePropertyChanged("FilePath");
                }
            }
        }
        public override string ToString()
        {
            return System.IO.Path.GetFileName(FilePath);
        }
    }
    
