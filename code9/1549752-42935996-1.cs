    [Serializable]
    public class OrderStatusDialog
    {
        public OrderStatusLookupOptions? LookupOption;
    
        public int OrderNumber;
    
        public string DeliveryAddress
    
        public static IForm<OrderStatusDialog> BuildForm()
        {
            return new FormBuilder<OrderStatusDialog>()
                .Message("In order to look up the status of a order, we will first need either the order number or your delivery address.")
                .Field(nameof(OrderStatusDialog.LookupOption))
                .Field(new FieldReflector<OrderStatusDialog>(nameof(OrderStatusDialog.OrderNumber))
                    .SetActive(state => state.LookupOption == OrderStatusLookupOptions.OrderNumber))
                .Field(new FieldReflector<OrderStatusDialog>(nameof(OrderStatusDialog.DeliveryAddress))
                    .SetActive(state => state.LookupOption == OrderStatusLookupOptions.Address))
                .Build();
        }
    }
