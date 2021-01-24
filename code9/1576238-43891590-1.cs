    public int GetProductQuantitySummary(int productId)
    {
        using (var cn = new SqlConnection("..."))
        using (var cm = new SqlCommand("", cn))
        {
            cn.Open();
            cm.CommandText = @"
                SELECT   SUM(qty) SumQty
                FROM     Products
                WHERE    product_id = @product_id";
            cm.Parameters.AddWithValue("@product_id", productId);
            return cm.ExecuteScalar() as int? ?? 0;
        }
    }
