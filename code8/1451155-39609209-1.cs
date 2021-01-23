    public void OnMasterColumnChanged(BCE.AutoCount.Invoicing.Sales.SalesOrder.SalesOrderMasterColumnChangedEventArgs e)
    {
        if (e.MasterRecord.GetDetailRecord.Count == 0)
            return;
        
        e.MasterRecord.GetDetailRecord(0).YourPONo = TxtBox1.Text;
            
        if (e.MasterRecord.GetDetailRecord.Count < 3)
            return;
        for (int i = 2; i < e.MasterRecord.DetailCount; i++)
        {
            if (e.MasterRecord.GetDetailRecord(i).YourPONo == e.MasterRecord.GetDetailRecord(i - 1).YourPONo)
            {
                e.MasterRecord.GetDetailRecord(i).YourPONo = TxtBox1.Text;
            }
        }
    }
