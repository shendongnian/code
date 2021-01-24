    public class AddItems : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        private string id;
        private string itemName;
        private object date;
        private decimal qty;
        private decimal buyPrice;
        private decimal totalPrice;
        public string ID 
        {
            set
            {
			    this.id = value;
				this.OnPropertyChanged("ID");
		    }
			get{return this.id;}
        }
        public string ItemName 
		{
            set
            {
			    this.itemName = value;
				this.OnPropertyChanged("ItemName");
		    }
			get{return this.itemName;}
        }
        public object Date 
		{
            set
            {
			    this.date = value;
				this.OnPropertyChanged("Date");
		    }
			get{return this.date;}
        }
        public decimal Qty 
		{
            set
            {
			    this.qty = value;
				this.OnPropertyChanged("Qty");
		    }
			get{return this.qty;}
        }
        public decimal BuyPrice 
		{
            set
            {
			    this.buyPrice = value;
				this.OnPropertyChanged("BuyPrice");
		    }
			get{return this.buyPrice;}
        }
        public decimal TotalPrice 
		{
            set
            {
			    this.totalPrice = value;
				this.OnPropertyChanged("TotalPrice");
		    }
			get{return this.totalPrice;}
        }
		
		public void AddQuantity(decimal quantity)
		{
			this.qty = this.qty + quantity;
		}
    }
