    public void VerwijderProductOrder(int id)
        {
            con.Open();
                    string query = "delete from ProductOrder where OrderID = " + id;
                    cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
            ProductOrder.RemoveAll(p => p.OrderId == id);
            con.Close();
        }
