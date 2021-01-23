    public void getAllData(DataTable table, string stockCode, string description, string unit, string quantity, string costPrice,
          string saleprice, string taxcode)
        {
            int index = table.Rows.Count > 0 ? table.Rows.Count : 0;
            DataRow dr = table.NewRow();
            dr[0] = stockCode;
            dr[1] = description;
            dr[2] = quantity;
            dr[3] = 0;
            dr[4] = unit;
            dr[5] = taxcode;
            dr[6] = saleprice;
            
            table.Rows.InsertAt(dr, index);
            table.AcceptChanges();
        }
