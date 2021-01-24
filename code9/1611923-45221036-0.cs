    public class OrderLineViewModel
    {
        private OrderLine _model;
        public OrderLineViewModel(OrderLine model)
        {
            _model = model;
        }
        public decimal Price
        {
            get
            {
                return _model.Price/100.0m;
            }
            set
            {
                _model.Price = value * 100.0m;
            }
        }
    }
