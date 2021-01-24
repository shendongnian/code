        public event PropertyChangedEventHandler PropertyChanged;
        private string itemText;
        public string ItemText
        {
            get
            {
                return itemText;
            }
            set
            {
                itemText = value;
                NotifyPropertyChanged("ItemText");
            }
        }
        private string itemDetail;
        public string ItemDetail
        {
            get
            {
                return itemDetail;
            }
            set
            {
                itemDetail = value;
                NotifyPropertyChanged("ItemDetail");
            }
        }
        private void NotifyPropertyChanged(string propName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
