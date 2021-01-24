    public class MaterialesCL : INotifyPropertyChanged
    {
        public int Material { get; set; }
        public string Descripcion { get; set; }
        public string DescCompuesta { get; set; }
        private bool _ischecked;
        public bool IsChecked
        {
            get { return _ischecked; }
            set 
            { 
                _ischecked = value; 
                OnPropertyChanged("IsChecked"); 
            }
        }
        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
