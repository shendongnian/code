    try
    {
       DataTable data = new DataTable();
       connection.Open();
       MySqlCommand command = new MySqlCommand("SELECT * FROM User", connection);
       data.load(command.ExecuteReader());
       foreach(Datarow row in data.rows)
       {
          // access your record colums by using reader
          Console.WriteLine(row["COLUMN_NAME"]);
       }
      
    }
    catch (Exception ex)
    {
       // handle exception here
    }
    finally
    {
      connection.Close();
    }
