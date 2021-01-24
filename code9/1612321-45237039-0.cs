    public class Data : Model
    {
        private ObservableCollection<Item> Bundle;
        private DataBase database;
        public Data()
        {
            Bundle = database.GetItems();
            Bundle.CollectionChanged += UpdateDatabase;
        }
        private bool _doUpdate = true;
        private void UpdateDataBase(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (!_doUpdate)
                return;
            if (e.OldItems != null)
            {
                database.Delete(e.OldItems);
            }
            if (e.NewItems != null)
            {
                database.Insert(e.NewItems);
            }
        }
        public void Refresh()
        {
            _doUpdate = false; //suspend updates...
            ObservableCollection<Item> NewItems = database.GetItems();
            Bundle.Clear();
            foreach (Item item in NewItems)
            {
                Bundle.Add(item);
            }
            _doUpdate = true; //resume updates...
        }
    }
