    public void VerwijderOrder(int id)
    {
        List<ProductOrder> deletes = new List<ProductOrder>();
        con.Open();
        foreach (ProductOrder po in ProductOrder)
        {
             if (po.OrderId == id)
             {
                  string query = "delete from [Order] where OrderID = " + id;
                  cmd = new SqlCommand(query, con);
                  deletes.Add(po);
             }
        }
        con.Close();
        
        deletes.forEach(d => ProductOrder.Remove(d));
    }
