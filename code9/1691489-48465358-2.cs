    public class MyViewModel : ObservableObject 
    {
        public MyViewModel()
        {
            //this is just an example of some test data:
            var myData = new List<Order> {
                new Order { OrderId = 1, Description = "Test1"},
                new Order { OrderId = 2, Description = "Test2"},
                new Order { OrderId = 3, Description = "Test3"}
            };
            //Now add the data to the collection:
            OrderList = new ObservableCollection<Order>(myData);
        }
        private ObservableCollection<Order> _orderList;
        public ObservableCollection<Order> OrderList
        {
            get { return _orderList; }
            set { SetProperty(ref _orderList, value); }
        } 
    }
