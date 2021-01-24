    public void Process()
    {
        try
        {
            int ptr = PayloadOffset + 1;
            var cPair = MessageData.GetString(ref ptr, 7);
            var orderID = MessageData.GetString(ref ptr, 15);
            if (Book.CPairs.TryGetValue(cPair, out CPairGroup cPairGroup) && cPairGroup != null)
            {
                for (int i = cPairGroup.BPrices.Count - 1; i >= 0; i--)
                {
                    var x = cPairGroup.BPrices[i];
                    for (int j = x.BOrders.Count - 1; j >= 0; j--)
                    {
                        var y = x.BOrders[j];
                        if (y.OrderID.Equals(orderID))
                        {
                            x.BOrders.RemoveAt(j);
                        }
                    }
                    if (x.BOrders.Count == 0)
                    {
                        cPairGroup.BPrices.RemoveAt(i);
                    }
                }
            }
        }
    }
