    OracleCommand cmd = new OracleCommand();//object of command
    cmd.Connection = orc;
    cmd.CommandType = CommandType.Text; // declare command type
    
    // explicitly add column names
    cmd.CommandText = "insert into Product (product_name, quality, quantity, price, product_image) values( :b, :c, :d, :a, :p)";
    cmd.Parameters.Add(":b", product_name); //add paramenter
    cmd.Parameters.Add(":c", quality);
    cmd.Parameters.Add(":d", quantity);
    cmd.Parameters.Add(":a", price);
    cmd.Parameters.Add(":p", product_image);
    int i = cmd.ExecuteNonQuery();
