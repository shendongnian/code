    public void BeforeSave(BCE.AutoCount.Invoicing.Sales.SalesOrder.SalesOrderBeforeSaveEventArgs e)
    {
        bool hasEmpty = false;
        for (int i = 0; i < e.MasterRecord.DetailCount; i++)
        {
            if (String.IsNullOrEmpty(e.MasterRecord.GetDetailRecord(i).YourPONo.ToString()))
            {
                hasEmpty = true;
            }
        }
        if (hasEmpty) {
            MessageBox.Show("You left Your PO No empty. Please check it carefully.");
        }
    }
