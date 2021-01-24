            if (tableSalesOrder == null)
            {
                tableSalesOrder = new DataTable("dtSO");
                DataColumn colItemCode = new DataColumn("ItemCode",typeof(string));
                tableSalesOrder.Columns.Add(colItemCode);
            }
            else
            {
                tableSalesOrder.Clear();
            }
