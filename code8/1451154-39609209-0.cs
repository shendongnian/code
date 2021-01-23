    public void OnMasterColumnChanged(BCE.AutoCount.Invoicing.Sales.SalesOrder.SalesOrderMasterColumnChangedEventArgs e)
    {
        // add check that e.MasterRecord.GetDetailRecord.Count > 0 and so on
        e.MasterRecord.GetDetailRecord(0).YourPONo = TxtBox1.Text;
        for (int i = 2; i < e.MasterRecord.DetailCount; i++)
        {
            if (e.MasterRecord.GetDetailRecord(i).YourPONo == e.MasterRecord.GetDetailRecord(i - 1).YourPONo)
            {
                e.MasterRecord.GetDetailRecord(i).YourPONo = TxtBox1.Text;
            }
        }
    }
