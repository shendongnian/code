    // Function to get all the product listing for a given product name in ascending order
    public void UpdateProductListing(string myConnString, String productName, Int productQty)  
    {
        MySqlConnection myConnection = new MySqlConnection(myConnString);
        MySqlCommand myCommand = (MySqlCommand)myConnection.CreateCommand();
        // Warning : never use String query, instead use parametrized query by calling myCommand.Parameters.AddWithValue
        myCommand.CommandText = "SELECT Id, Product, Qty, Expiration FROM YourDb.YourTable ORDER BY Expiration ASC";
        myConnection.Open();
        // The reader enables us to acces each row by calling it's read method
        MySqlDataReader myReader = myCommand.ExecuteReader();
        try 
        {
                // QtyRemaining variable will hold how much of the quatity is to be taken from next row.
                Int QtyRemaining = productQty;
                // Always call Read before accessing data.
                while (myReader.Read()) 
                {                    
                    if (myReader.GetInt16(2) >= productQty)
                    {
                        Int NewQty = myReader.GetInt16(2) - productQty;
                        // At this moment i'm not sure if you need to close the reader before Inserting.
                        // Anyways you'll require to arrange this code in a proper order to suite your situation
                        MySqlCommand InsertCommand = (MySqlCommand) myConnection.CreateCommand();
                        // Warning : never use String query, instead use parametrized query by calling myCommand.Parameters.AddWithValue
                        InsertCommand.CommandText = "Insert INTO YourDb.YourTable (Qty) VALUES (" + NewQty.toString()  + ") WHERE Id=" + myReader.GetInt16(0).toString();
                        InsertCommand.ExecuteNonQuery();
                        break;
                    }
                    else
                    {
                        // Now we know that this particular row cannot supply the entire qty, so we'll set it to zero and move to next row for remaining qty
                        MySqlCommand InsertCommand = (MySqlCommand) myConnection.CreateCommand();
                        // Warning : never use String query, instead use parametrized query by calling myCommand.Parameters.AddWithValue
                        InsertCommand.CommandText = "Insert INTO YourDb.YourTable (Qty) VALUES (" + 0.toString()  + ") WHERE Id=" + myReader.GetInt16(0).toString();
                        InsertCommand.ExecuteNonQuery();
                        
                        // the quantity to be captured from next row
                        QtyRemaining =  productQty - myReader.GetInt16(2);
                    }                    
                }
        }
        finally 
        {
                // always call Close when done reading.
                myReader.Close();
                // Close the connection when done with it.
                myConnection.Close();
        }
    }
