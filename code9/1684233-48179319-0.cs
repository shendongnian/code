    ItemFulfillment itemFulfillment = new ItemFulfillment()
    {
        createdFrom = new RecordRef() {  type = RecordType.salesOrder, internalId = "7795181" },
        itemList = new ItemFulfillmentItemList()
        {
            replaceAll = false,
            item = new ItemFulfillmentItem[]
            {
                new ItemFulfillmentItem()
                {
                    orderLine = 1,
                    orderLineSpecified = true,
                    quantity = 1,
                    quantitySpecified = true,
                },
            }
        },
    };
