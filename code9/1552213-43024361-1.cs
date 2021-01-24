    // MODEL:
    public class Model
    {
        ObservableCollection<Item> ListOfItems;
    }
    public class Item
    {
    }
    // VIEWMODELS:
    public class MainWindowViewModel
    {
        Model Model { get; set; }
        Tab1ViewModel Tab1ViewModel { get; set; }
        Tab2ViewModel Tab2ViewModel { get; set; }
        public MainWindowViewModel()
        {
            Model = new Model();
            Tab1ViewModel = new Tab1ViewModel(Model);
            Tab2ViewModel = new Tab2ViewModel(Model);
        }
    }
    public class Tab1ViewModel
    {
        ObservableCollection<ItemViewModel> ItemViewModels { get; set; } // Bind it to ListBox's ItemsSource
        public Tab1ViewModel(Model m)
        {
            ItemViewModels = new ObservableCollection<ItemViewModel>();
            // Populate ItemViewModels and keep it in sync with ListOfItems model by subscribing to its CollectionChanged event.
        }
    }
    public class Tab2ViewModel
    {
        ObservableCollection<ItemViewModel> ItemViewModels { get; set; } // Bind it to ListBox's ItemsSource
        public Tab2ViewModel(Model m)
        {
            ItemViewModels = new ObservableCollection<ItemViewModel>();
            // Populate ItemViewModels and keep it in sync with ListOfItems model by subscribing to its CollectionChanged event.
        }
    }
    public class ItemViewModel
    {
        Item Item { get; set; } // Model
        public ItemViewModel(Item item)
        {
            Item = item;
        }
    }
