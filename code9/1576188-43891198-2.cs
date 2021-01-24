    public class VisibleItemViewModel : INotifyPropertyChanged {
        ///here you can write the logic to filter and populate Listbox based on 
        //selection changed of combobox
        public VisibleItemViewModel() {
            populateCombo();
            getDataList();
        }
        private VisibleItem selectedItem;
        public VisibleItem SelectedItem {
            get { return selectedItem; }
            set {
                selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }
        private int selectedComboIndex;
        public int SelectedComboIndex {
            get { return selectedComboIndex; }
            set {
                selectedComboIndex = value;
                //your filter logic goes here
                selectedItemChanged(selectedComboIndex);
                OnPropertyChanged("SelectedComboIndex");
            }
        }
        public ObservableCollection<int> ComboBoxList { get; set; }
        private void populateCombo() {
            ComboBoxList = new ObservableCollection<int>();
            for (int i = 1; i <= 6; i++) {
                ComboBoxList.Add(i);
            }
        }
        private ObservableCollection<VisibleItem> visibleItems;
        public ObservableCollection<VisibleItem> VisibleItems {
            get ;
            set;
        }
        private void selectedItemChanged(int item) {
            ///your filter logic goes here
          VisibleItems =new ObservableCollection<VisibleItem>(visibleItems.Take(item));
            OnPropertyChanged("VisibleItems");
        }
        private ObservableCollection<VisibleItem> getDataList() {
            VisibleItem vItem;
            visibleItems = new ObservableCollection<VisibleItem>();
            for (var k = 1; k < 10; k++) {
                vItem = new VisibleItem();
                vItem.Group = "Group " + k;
                vItem.Name = "Item Name  " + k;
                vItem.PictureID = k;
                vItem.SomeDetail = "Detail  " + k;
                vItem.Info = "Info  " + k;
                vItem.GHeaderName = "GHeaderName " + k;
                vItem.Info = "Info  " + k;
                // vItem.Class
                visibleItems.Add(vItem);
            }
            return visibleItems;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName) {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
