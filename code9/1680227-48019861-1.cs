    ObservableCollection<MyModel> list = new ObservableCollection<MyModel>();
    for (int i=0; i<10; i++)
    {
        list.Add(new MyModel { Admin = "admin" + i, Clients = "client", Tickets = "tickets" });
    }
    MyListView.ItemsSource = list;
    public class MyModel
    {
        public string Admin { set; get; }
        public string Tickets { get; set; }
        public string Clients { get; set; }
    }
