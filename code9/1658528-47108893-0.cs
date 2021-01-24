    List<string> rows = new List<string>(
        new string[] { "Item", "Quantity", "Price" });
            
    GdItemList.Columns[0].HeaderText = Convert.ToString(rows[0]);
    GdItemList.Columns[1].HeaderText = rows[1].ToString();
    GdItemList.Columns[2].HeaderText = rows[2].ToString();
