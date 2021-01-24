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
    
