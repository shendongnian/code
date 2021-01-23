    class MyDropDownList : DropDownList, INotifyPropertyChanged
    {
        event PropertyChangedEventHandler PropertyChanged;
    
        public override SelectedIndex
        {
            set 
            {
                base.SelectedIndex = value;
                PropertyChanged(new PropertyChangedEventArgs("SelectedIndex"));
            }
            get
            {
                return base.SelectedIndex;
            }
        }
    }
