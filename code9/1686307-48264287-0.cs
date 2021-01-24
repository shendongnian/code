    string tableName = "Person";
    // the names of the columns in your table    
    var columnNames = new List<string> { "Name", "Age", "BirthDate" };
    // the data you want to store in each column
    var data = new List<string> { "Klaus", "22", "Before 2010" };
    var myColumns = string.Join (", ", columnNames.Select (n => string.Format("[{0}]",n)));
    var myParamColumns = string.Join (", ", columnNames.Select (n => string.Format("@{0}",n)));
    using (var dbCommand = new SqlCommand() /*conDataBase.CreateCommand ()*/)
    { 
        dbCommand.CommandText = string.Format ("insert into {0}  ( {1} ) values ( {2} );", tableName, myColumns, myParamColumns);
        // your insert now looks like this:
        // insert into Person  ( [Name], [Age], [BirthDate] ) values ( @Name, @Age, @BirthDate );
    
        Console.WriteLine (dbCommand.CommandText);
        // then you add each single piece of data to each used @....    
        for (int i = 0; i < columnNames.Count; i++)
          dbCommand.Parameters.AddWithValue (columnNames[i], data[i]);
    
        dbCommand.ExecuteNonQuery ();
    }
