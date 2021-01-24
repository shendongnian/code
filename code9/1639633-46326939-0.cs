    public class ResidentViewModel
    {
        public ResidentViewModel()
        {
            FullItemList = CollectionViewSource.GetDefaultView(_itemList);
            Load();
        }
        private ObservableCollection<Res_details> _itemList { get; set; }
        public ICollectionView FullItemList { get; private set; }
        private void Load()
        {
            var items = new ObservableCollection<Res_details>();
            using (var db = new Access5687DB())
            {
                var q =
                    from c in db.Residents
                    select c;
                foreach (var c in q)
                {
                    items.Add(new Res_details()
                    {
                        ID = c.Room,
                        Name = c.Firstname,
                        LastName = c.Lastname,
                        Birthday = c.Birthday,
                        Arrival = c.Admission,
                    });
                }
                _fullItemList = items;
            }
        }
        /*Apply filter to the collection view*/
        private void ShowEmptyLinesOnly(object parameter)
        {
            /*logic based on your parameter here*/
            
            FullItemList.Filter = FilterEmptyLine;//<-- set filter to collection view
            FullItemList.Refresh();
        }
        private bool FilterEmptyLine(object o)
        {
            var item = o as Res_details;
            if (item == null) return false;
            /*
             * decide if item is 'empty' and return true in case item is empty;
             */
        }
        private ICommand filter_Empty;
        public ICommand Filter_Empty
        {
            get { if (filter_Empty == null) filter_Empty = new FilterObs(ShowEmptyLinesOnly); return filter_Empty; }
            set { filter_Empty = value; }
        }
        private class FilterObs : ICommand
        {
            public event EventHandler CanExecuteChanged;
            private readonly Action<object> _filterAction;
            public FilterObs(Action<object> filterAction)
            {
                _filterAction = filterAction;
            }
            public bool CanExecute(object parameter)
            {
                if ((string)parameter == "B")
                    return
                        true;
                if ((string)parameter != "B")
                    return
                        false;
                else
                    return
                        false;
            }
            public void Execute(object parameter)
            {
                _filterAction.Invoke(parameter);
            }
        }
    }
