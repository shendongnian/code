       dtDetail.ColumnChanged += dtDetail_ColumnChanged;
    
        static void dtDetail_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            if (e.Column.ColumnName == "Qty")
            {
                int sum = 0;
               // dtMaster.Columns.Add("TotalQty"
                foreach(DataRow row in ds.Tables["Detail"].Rows)
                {
                    if (row["Qty"] != DBNull.Value && Convert.ToString(row["CID"]) != Convert.ToString(e.Row["CID"]))
                    {
                        sum += Convert.ToInt32(row["Qty"]);
                    }
                }
                sum += Convert.ToInt32(e.Row["Qty"]);
                ds.Tables["Master"].Rows[0]["TotalQty"] = sum;
                   
            }
        }
