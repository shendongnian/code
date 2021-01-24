     public class VisibleItemViewModel : INotifyPropertyChanged {
        ///here you can write the logic to filter and populate Listbox based on 
       //selection changed of combobox
        private VisibleItem selectedItem;
        public VisibleItem SelectedItem {
            get { return selectedItem; }
            set {
                selectedItem = value;
                //your filter logic goes here
                selectedItemChanged(selectedItem);
                OnPropertyChanged("SelectedItem");
            }
        }
        private ObservableCollection<VisibleItem> visibleItems;
        public ObservableCollection<VisibleItem> VisibleItems {
            get {
                if (visibleItems = null)
                    visibleItems = getDataList();
                return visibleItems;
            }
            set { visibleItems = value; }
        }
        private void selectedItemChanged(VisibleItem item) {
            ///your filter logic goes here
        }
        private ObservableCollection<VisibleItem> getDataList() {
            VisibleItem vItem;
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
                dataList.Add(vItem);
            }
            return dataList;
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName) {
            if (PropertyChanged !=null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
