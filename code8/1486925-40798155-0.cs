    void OnPropertyChanged(string prop)
            {
                if (this.PropertyChanged != null)
                    this.PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
