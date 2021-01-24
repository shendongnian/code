    public int CreateAdmin (string product_name, string quality, string quantity, string price, string product_image)
    {
      string connectionString = "User Id=hr;Password=hr;Data Source=localhost:1521/xe";
      using (var orc = new OracleConnection (connectionString))
      {
        using (var cmd = orc.CreateCommand ())
        {
          cmd.CommandType = CommandType.Text; // declare command type
          // Product has exactly 5 or 5 + 1 auto-inc ID column, else provide the
          // column names as well: 
          // insert into Product ( name,qual,quant,price,img ) values( @b, @c, @d, @a, @p)";
          cmd.CommandText = "insert into Product values( @b, @c, @d, @a, @p)"; // -> : to @
          cmd.Parameters.Add ("@b", product_name); //add paramenter
          cmd.Parameters.Add ("@c", quality);
          cmd.Parameters.Add ("@d", quantity);
          cmd.Parameters.Add ("@a", price);
          cmd.Parameters.Add ("@p", product_image);
          //da.InsertCommand = cmd;
          int i = cmd.ExecuteNonQuery ();
          return i;
        }
      }
    }
