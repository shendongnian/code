    MyCollection = new ObservableCollection<clsItemsModel>(_clsItemsDataService.GetItems()
                       .OrderByDescending(p => 
                       {
                           int n;
                           return int.TryParse(p.Items, out n) ? n : int.MinValue;
                       }));
