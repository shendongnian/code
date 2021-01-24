    string sql = 
        "INSERT INTO CustomerTrans" +
        "   (TableName, UserID, UserName, SumQuantity, SumPrice, SumRealPrice, SumExtrasPrice, SumTotal, SumDiscountTotal, DateTime)" +
        "  SELECT @TableName, @UserID, @Username, Sum(Quantity), Sum(Price), Sum(RealPrice), Sum(ExtrasPrice), Sum(Quantity * Price), Sum(Quantity * DiscountPrice), current_timestamp" +
        "  FROM InventoryTransTemp" +
        "  WHERE active=1 and TableName= @TableName;\n" +
        "SELECT @TranID = scope_identity;\n"
        "UPDATE InventorytransTemp" + 
        "  SET TrnDocumentID=@TranID ,Active=0" + 
        "  WHERE TableName= @Tablename and Active=1;"; 
    
    using (var con = new SqlConnection("connection string here"))
    using (var cmd = new SqlCommand(sql, con))
    {
        //I'm guessing at exact column types/lengths here. 
        // You should update this to use your exact column types and lengths.
        // Don't let ADO.Net try to guess this for you.
        cmd.Parameters.Add("@TableName", SqlDbType.NVarChar, 20).Value = Connection.TableName;
        cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = Connection.UserID;
        cmd.Parameters.Add("@Username", SqlDbType.NVarChar, 20).Value = Connection.Username;
        cmd.Parameters.Add("@TranID", SqlDbType.Int).Value = 0; //placeholder only
        con.Open();
        cmd.ExecuteNonQuery();
    }
