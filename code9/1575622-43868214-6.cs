    public class Presenter
    {
        ObservableCollection<ListItem> m_ListItems = new ObservableCollection<ListItem>(); 
        public ObservableCollection<List> ListItems
        {
            get { return m_ListItems; }
        }
    
        public Presenter(MeView view)
        { 
            Binding binding = new Binding("ListItems");
            binding.Source = ListItems;
            view.MeListView.SetBinding(ListView.ItemsSourceProperty, binding);
            // other view events, bindings etc.
        }
    }
