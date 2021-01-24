    View Model
    namespace MyNamesapce
    {
    public OrderInfoViewModel
    {
        public string OrderTitle { get; set; }
        public IEnumerable<OrderItem> OrderItems { get; set; }
    }
