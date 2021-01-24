    public class CustomExtensions : INotifyPropertyChanged
    {
        public string Extension { get; set; }
    
        private bool _checked;
        public bool Checked 
        {
            get { return _checked; }
            set
            {
                if (_checked == value) return;
                _checked = value;
                RaisePropertyChanged("Checked");
            }
        }
    
        public CustomExtensions(string ext)
        {
            Extension = ext;
            Checked = true;
        }
    
        public virtual event PropertyChangedEventHandler PropertyChanged;
        protected virtual void RaisePropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
