    class Presenter : INotifyPropertyChanged
    {
        public ObservableCollection<ListItemPresenter> ListItems
        {
            get { return GetItems(); }
            set { SetItems(value); }
        }
    
        ObservableCollection<ListItemPresenter> GetItems()
        {
            // private logic to retrieve `ListItemPresenter` collection from model
            var collection = new ObservableCollection<ListItemPresenter>();
            foreach(ListItem listItem in Model.Items)
                collection.Add(listItem.GetPresenter());
            return collection;
        }
    
        void SetItems(ObservableCollection<ListItemPresenter> objects)
        {
            // private logic to transfer `ListItemPresenter` collection to model
            // remember to call NotifyPropertyChanged("ListItems");
            Model.Items.Clear();
            foreach(ListItemPresenter presenter in objects)
                Model.Items.Add(presenter.GetModel());
            NotifyPropertyChanged("ListItems");
        }
    }
