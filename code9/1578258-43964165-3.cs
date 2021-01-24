    public class ItemsViewModel : ViewModelBase {
        public ItemsViewModel() {
            items = new ObservableCollection<MemEntity>();
        }
        private MemEntity selectedItem;
        public MemEntity SelectedItem {
            get { return selectedItem; }
            set {
                if (selectedItem != value) {
                    selectedItem = value;
                    OnPropertyChanged(); //this will raise the property changed event.
                }
            }
        }
        public ObservableCollection<MemEntity> items { get; set; }
    }
