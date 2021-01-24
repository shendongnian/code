                DataTable dt = new DataTable();
                dt.Columns.Add("ItemCode", typeof(string));
                dt.Columns.Add("Description", typeof(string));
                dt.Columns.Add("BoxQty", typeof(int));
                dt.Columns.Add("PalletQty", typeof(int));
                dt.Columns.Add("Weight", typeof(decimal));
                dt.Columns.Add("Barcode", typeof(string));
                
                //inside while  loop
                dt.Rows.Add(new object[] {itemCode, description, boxQty, palletQty, weight, barcode});
