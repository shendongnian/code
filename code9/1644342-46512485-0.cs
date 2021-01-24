    private void SubtractInventory(string product, int qty)
    {
        string connectionString = "connection sting goes here";
        try
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                string sql = $"select ID, PRODUCT, QTY, EXPIRES from PRODUCTS order by EXPIRES asc";
                using (SqlDataAdapter adapter = new SqlDataAdapter(sql, cn))
                {
                    using (DataTable tempTable = new DataTable())
                    {
                        adapter.Fill(tempTable);
                        if (tempTable.Rows.Count == 0) throw new Exception("No such product.");
                        foreach (DataRow r in tempTable.Rows)
                        {
                            int newQty = (int)r["QTY"] - qty;
                            if (newQty >= 0)
                            {
                                r["QTY"] = newQty;
                                qty = 0;
                                break;
                            }
                            else
                            {
                                qty = qty - (int)r["QTY"];
                                r["QTY"] = 0;
                            }
                        }
                        if (qty > 0) throw new Exception($"Not enough of {product} in inventory to subtract {qty}.");
                        using (SqlCommandBuilder cb = new SqlCommandBuilder(adapter))
                        {
                            adapter.UpdateCommand = cb.GetUpdateCommand();
                            adapter.Update(tempTable);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            // log ex.Message somehow..
        }
