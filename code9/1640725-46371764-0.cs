    //...
    OleDbCommand dbCommand = dbConnection.CreateCommand();
    dbCommand.CommandType = CommandType.Text;
    var sb = new System.Text.StringBuilder();
    sb.Append("select count(*) as Total_Source from [dbo].A;"); // Notice semicolon at the end of the string.
    sb.Append("select count(*) as Total_Destination from [dbo].B;");
    sb.Append("select count(*) as Total_Blank from [dbo].C where ColumnA = '';");
    dbCommand.CommandText = sb.ToString();
    OleDbDataReader dbReader = dbCommand.ExecuteReader();
 
    //...
