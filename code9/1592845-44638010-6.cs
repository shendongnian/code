           void AddItemClicked(object sender, EventArgs e)
            {
                SampleData data = new SampleData();
                data.ItemText = "An Item";
                data.ItemDetail = "Item - " + (itemsListCollection.Count + 1).ToString();
                itemsListCollection.Add(data);
    
                ItemsListView.HeightRequest = itemsListCollection.Count * 60;
                //ForceLayout();
            }
        void RemoveItemClicked(object sender, EventArgs e)
        {
            SampleData item =(SampleData)((MenuItem)sender).CommandParameter;
            if (item != null)
            {
                itemsListCollection.Remove(item);
            }
            ItemsListView.HeightRequest = itemsListCollection.Count * 60;
        }
    
    class SampleData:INotifyPropertyChanged
    {
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
