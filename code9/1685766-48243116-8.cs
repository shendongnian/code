    public static class BobsThirdPartyItemExtensions
    {
        public static MyOrder ToMyOrder(this ThirdPartyOrderV1 source)
        {
            return new MyOrder
            {
                Amount = new Money(source.Amount, Currency.USD),
                Lines = source.LineItems.Select(item => item.ToMyOrderItem()).ToArray()
            };
        }
        public static MyOrderItem ToMyOrderItem(this ThirdPartyOrderItemV1 source)
        {
            return new MyOrderItem
            {
                ItemId = new ItemId
                {
                    ItemType = OrderItemType.BobsThirdPartyItems,
                    Value = source.ItemID.ToString("0")
                },
                Quantity = source.Quantity
            };
        }
    }
    var myOrder = someThirdPartyV1order.ToMyOrder();
