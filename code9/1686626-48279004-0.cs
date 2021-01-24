        public class DataItem
        {
            public string Column1 { get; set; }
            public string Column2 { get; set; }
            
        }
        private void populategrid()
        {
            ObservableCollection<DataItem> list = new ObservableCollection<DataItem>();
            list.Add(new DataItem { Column1 = "", Column2 = "" });
            list.Add(new DataItem { Column1 = "", Column2 = "" });
            list.Add(new DataItem { Column1 = "", Column2 = "" });
            list.Add(new DataItem { Column1 = "", Column2 = "" });
            myDataGrid.ItemsSource = list;
        }
