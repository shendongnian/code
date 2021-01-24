    private static void MakeApiCallsForStore(int ShipToStoreID, List<dfill> dfills)
        {
            do
            {
            var ThisOrderID = Guid.NewGuid();
            List<dfill> AllDfillsForThisOrder = db.//grab all dfills with the same order_no
            var OrderLog = new PurchaseOrder();
            OrderLog.ID = ThisOrderID;
            OrderLog.BillToStoreID = LogisticsStoreID;
            OrderLog.ShipToStoreID = ShipToStoreID;
            OrderLog.EstimatedArrivalDate = DateTime.Now;
            OrderLog.DfillsOnThisOrder = new List<dfill>();
            OrderLog.DfillsOnThisOrder.AddRange(AllDfillsForThisOrder);
            db.PurchaseOrderLogs.Add(OrderLog);
        } while ([condition]); 
        db.SaveChanges();
    }
