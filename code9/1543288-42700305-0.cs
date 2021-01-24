        public override string itemName
        {
            get
            {
                return itemName;
            }
            set
            {
                itemName = value;
                NotifyPropertyChanged("itemName");
                NotifyChange(itemName); 
            }
        } 
