    private void calculate()
    {
        // Transaction: Id_Item, qtyOUT
        IEnumerable<ItemOut> contextItemOut = null;
        // ItemDetail: No, Id_Item, qty
        IEnumerable<ItemDetail> contextItemDetails = null;
        Dictionary<int, decimal> itemOutQuantities = contextItemOut.ToDictionary(x => x.Id_Item, x => x.qtyOUT);
        var itemDetails = contextItemDetails.OrderBy(x => x.No).ToList();
        // Data for ITEM_TRANSACTION
        ICollection<ItemTransaction> transactions = new List<ItemTransaction>();
        foreach (var item in itemDetails)
        {
            decimal outQty;
            if (itemOutQuantities.TryGetValue(item.Id_Item, out outQty))
            {
                var qtyChange = Math.Min(outQty, item.qty);
                item.qty -= qtyChange;
                outQty -= qtyChange;
                if (outQty == 0)
                {
                    itemOutQuantities.Remove(item.Id_Item);
                }
                else
                {
                    itemOutQuantities[item.Id_Item] = outQty;
                }
                if (qtyChange != 0)
                {
                    transactions.Add(new ItemTransaction { /*No = autoincrement, */ NoTrans = item.No, qtyOUT = qtyChange });
                }
            }
        }
        // itemDetails qty values are corrected
    }
