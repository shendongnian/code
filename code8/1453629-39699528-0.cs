    public void BeforeSave(BCE.AutoCount.Invoicing.Sales.SalesOrder.SalesOrderBeforeSaveEventArgs e)
        {
            int tt = 0;
            for (int i = 0; i < e.MasterRecord.DetailCount; i++)
            {
                if (tt == 0)
                {
                    if (String.IsNullOrEmpty(e.MasterRecord.GetDetailRecord(i).YourPONo.ToString()))
                    {
                        MessageBox.Show("You left Your PO No empty. Please check it carefully.");
                        tt = 1;
                    }
                }
            }
        }
