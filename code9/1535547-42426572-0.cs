    public void AddLineItemFulFilled(string itemID, int quantityOrdered, int quantityShipped)
    {
        var li = LineItems.FirstOrDefault(l => l.LineItemID.Equals(itemID));
        if (li == null)
          LineItems.Add(new LineItemModel(lineItem, quantityOdered, quantityShipped));
        else
            li.QuantityShipped += quantityShipped;
    }
