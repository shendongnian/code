     class MyViewModel : ViewModelBase
    {
        public MyViewModel()
        {
            this.SelectChangeMyItemsCommand = new BaseCommand(new Action(SelectChangeMyItems));
        }
        
        private ObservableCollection<MyItem> selectedMyItems = null;
        public ObservableCollection<MyItem> SelectedMyItems
        {
            get
            {
                if (selectedMyItems == null)
                {
                    selectedMyItems = new ObservableCollection<MyItem>();
                }
                return selectedMyItems;
            }
            set
            {
                selectedMyItems = value;
                OnPropertyChanged("SelectedMyItems");
            }
        }
        private ObservableCollection<MyItem> myItemsList = null;
        public ObservableCollection<MyItem> MyItemsList
        {
            get
            {
                if (myItemsList == null)
                {
                    MyItemsRefresh();
                }
                return myItemsList;
            }
            set
            {
                myItemsList = value;
                OnPropertyChanged("MyItemsList");
            }
        }
        public void MyItemsRefresh()
        {
            ObservableCollection<MyItem> tempMyList = new ObservableCollection<MyItem>();
            tempMyList.Add(new MyItem("Angry Apple"));
            tempMyList.Add(new MyItem("Big Bird"));
            tempMyList.Add(new MyItem("Candy Cane"));
            tempMyList.Add(new MyItem("Daring Dart"));
            MyItemsList = tempMyList;
        }
        private static bool iseven = true;
        public ICommand SelectChangeMyItemsCommand { get; private set; }
        public void SelectChangeMyItems()
        {
            ObservableCollection<MyItem> items = new ObservableCollection<MyItem>();
            for(int i = 0; i < myItemsList.Count; i++)
            {
                if (iseven && IsEven(i))
                {
                    items.Add(MyItemsList[i]);
                }
                else if (!iseven && !IsEven(i))
                {
                    items.Add(MyItemsList[i]);
                }
            }
            this.SelectedMyItems = items;
            iseven = !iseven;
        }
        public static bool IsEven(int value)
        {
            return value % 2 == 0;
        }
    }
