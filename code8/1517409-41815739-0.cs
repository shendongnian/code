    public class MyViewModel
    {
        public MyViewModel()
        {
            myItems = new ObservableCollection<MyItems>();
            for(int i=1;i<=10;i++)
            {
                MyItems item = new MyItems();
                item.Name = "Main Item " + i.ToString();
                ObservableCollection<MySubItems> subItems = new ObservableCollection<MySubItems>();
                for (int j=1;j<=5;j++)
                {
                    subItems.Add(new MySubItems() { Title = "Sub Item " + j.ToString() });
                }
                item.Data = subItems;
                myItems.Add(item);
            }
        }
        public ObservableCollection<MyItems> myItems { get; set; }
    }
    public class MyItems
    {
        public string Name { get; set; }
        public ObservableCollection<MySubItems> Data { get; set; }
    }
    public class MySubItems
    {
        public string Title { get; set; }
    }
