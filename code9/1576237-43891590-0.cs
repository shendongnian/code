    public DataTable GetProductQuantitySummary(int? productId)
    {
        using (var cn = new SqlConnection("...."))
        using (var cm = new SqlCommand   ("", cn))
        {
            cn.Open();
            cm.CommandText = @"
                SELECT   product_id, SUM(qty) SumQty
                FROM     Products
                WHERE    product_id = @product_id OR @product_id IS NULL
                GROUP BY product_id";
            cm.Parameters.AddWithValue("@product_id", (object) productId ?? DBNull.Value);
            var table = new DataTable();
            using (var reader = cm.ExecuteReader())
            {
                table.Load(reader);
            }
            return table;
        }
    }
