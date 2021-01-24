    public bool AddProducts(string productID, string productName, int productQuantity, decimal productPrice, string productCategory)
    {
        bool recordFound = false;
        try
        {
            using (var myCon = new SqlConnection("Connection-String from config-file"))
            using (var saveProduct = new SqlCommand("AddProduct", myCon))
            {
                saveProduct.CommandType = CommandType.StoredProcedure;
                saveProduct.Parameters.Add("@ProductID", SqlDbType.NVarChar).Value = productID;
                saveProduct.Parameters.Add("@ProductName", SqlDbType.VarChar).Value = productName;
                saveProduct.Parameters.Add("@ProductQuantity", SqlDbType.Int).Value = productQuantity;
                saveProduct.Parameters.Add("@ProductPrice", SqlDbType.Decimal).Value = productPrice;
                saveProduct.Parameters.Add("@ProductCategory", SqlDbType.NVarChar).Value = productCategory;
                myCon.Open(); // will be closed implicitely at the end of the using
                saveProduct.ExecuteNonQuery();
            }
        }
        catch (SqlException ex) when (new[] {2627, 2601}.Contains(ex.ErrorCode))
        {
            // index constraint
            recordFound = true;
        }
        catch
        {
            // log this!
            throw; // don't ignore it
        }
        return recordFound;
    }
