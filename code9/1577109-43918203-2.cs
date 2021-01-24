    public void VerwijderOrder(int id)
    {
    	con.Open();
    	string query = "delete from [Order] where OrderID = @id";
    	using (var con = new SqlConnection(connectionString))
    	using(var cmd = new SqlCommand(query, con))
    	{
    		con.Open();
    		cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
    		cmd.ExecuteNonQuery();
    	);
    	ProductOrder.RemoveAll(p=> p.OrderID == id);
    }
