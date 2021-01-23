    public void BeforeSave(BCE.AutoCount.Invoicing.Sales.SalesOrder.SalesOrderBeforeSaveEventArgs e) {
        bool flag = false;
        for (int i = 0; i < e.MasterRecord.DetailCount; i++) 
        { 
            if (String.IsNullOrEmpty(e.MasterRecord.GetDetailRecord(i).YourPONo.ToString())) 
            { 
                flag = true;
                break;
            } 
        } 
        if (flag)
            MessageBox.Show("You left Your PO No empty. Please check it carefully.");
    }
