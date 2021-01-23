    public void BeforeSave(BCE.AutoCount.Invoicing.Sales.SalesOrder.SalesOrderBeforeSaveEventArgs e)
    {
        for (int i = 0; i < e.MasterRecord.DetailCount; i++)
        {
            if (String.IsNullOrEmpty(e.MasterRecord.GetDetailRecord(i).YourPONo.ToString()))
            {
                MessageBox.Show("You left Your PO No empty. Please check it carefully.");
                break; // <--
            }
        }
    }
