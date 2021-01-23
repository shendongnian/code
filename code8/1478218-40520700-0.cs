    Object_Type itemsField {
       set {
           this._itemsField = value;
           onPropertyChanged("itemsField");
           }
       get{
           return this._itemsField;
           }
        }
    void OnPropertyChanged(string prop)
            {
                if (this.PropertyChanged != null)
                    this.PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
            public event PropertyChangedEventHandler PropertyChanged;
