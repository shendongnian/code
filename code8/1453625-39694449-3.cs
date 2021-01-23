    private int canSave;
    public void BeforeSave(BCE.AutoCount.Invoicing.Sales.SalesOrder.SalesOrderBeforeSaveEventArgs e)
    {
        if (Interlocked.CompareExchange(ref canSave, 0, 1) != 1)
        {
            // Any cancelation logic that's appropiate here
            return;
        }
        for (int i = 0; i < e.MasterRecord.DetailCount; i++)
        {
            if (String.IsNullOrEmpty(e.MasterRecord.GetDetailRecord(i).YourPONo.ToString()))
            {
                MessageBox.Show("You left Your PO No empty. Please check it carefully.");
                break; // <--
            }
        }
    }
