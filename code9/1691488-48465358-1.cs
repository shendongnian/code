    public class Order : ObservableObject 
    {
        private long _orderId;
        public long OrderId
        {
            get { return _orderId; }
            set { SetProperty(ref _orderId, value); }
        } 
        private string _description;
        public string Description
        {
            get { return _description; }
            set { SetProperty(ref _description, value); }
        } 
    }
