    System.Data.OleDb.OleDbConnection conn = new
                System.Data.OleDb.OleDbConnection();
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Your DataBasePath";
            conn.Open();
            System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "INSERT INTO TblProductDetails (ProductID, ProductName, Category, Section, UOM, CostPrice, SellingPrice1, SellingPrice2, DiscountPercentage, DiscountAmount, MinimumPrice, Vendor, Stock) VALUES(@ProductID, @ProductName, @Category, @Section, @UOM, @CostPrice, @SellingPrice1, @SellingPrice2, @DiscountPercentage, @DiscountAmount, @MinimumPrice, @Vendor, @Stock)";
            cmd.Parameters.AddWithValue("@ProductID", comboBox1.Text);
            cmd.Parameters.AddWithValue("@ProductName", textBox1.Text);
            cmd.Parameters.AddWithValue("@Category", textBox2.Text);
            cmd.Parameters.AddWithValue("@Section", textBox2.Text);
            cmd.Parameters.AddWithValue("@UOM", textBox4.Text);
            // continue Your Code its just example 
            cmd.Connection = conn;
           
            cmd.ExecuteNonQuery();
            conn.Close();
