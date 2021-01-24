    public int ChangeProduct(string _ProductID, double _ProductPrice)
        {
            int a = 0;
            string queryString = "UPDATE product SET productPrice = @productPrice WHERE productID = @productId";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                
                OleDbCommand updateProduct = new OleDbCommand(queryString, connection);
                updateProduct.Parameters.AddWithValue("@productPrice", _ProductPrice);
                updateProduct.Parameters.AddWithValue("@productId", _ProductID);
                connection.Open();
                a = updateProduct.ExecuteNonQuery();
                connection.Close();
            } 
            return a;
        }
