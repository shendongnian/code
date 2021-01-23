    //Create Connection to SQL Server
    SqlConnection SQLConnection = new SqlConnection();
    SQLConnection.ConnectionString = "Data Source = (local); Initial Catalog =TechBrothersIT; " + "Integrated Security=true;";
    System.IO.StreamReader SourceFile = new System.IO.StreamReader(SourceFolder+SourceFileName);
    string line = "";
    Int32 counter = 0;
    SQLConnection.Open();
    while ((line = SourceFile.ReadLine()) != null)
    {
        //skip the header row
        if (counter > 0)
        {
            //prepare insert query
            string query = "Insert into " + TableName +
                           " Values ('" + line.Replace(filedelimiter, "','") + "')";
           //execute sqlcommand to insert record
           SqlCommand myCommand = new SqlCommand(query, SQLConnection);
           myCommand.ExecuteNonQuery();
       }
       counter++;
    }
    SourceFile.Close();
    SQLConnection.Close();
    //Move the file to Archive folder
    File.Move(SourceFolder+SourceFileName, ArchiveFodler + SourceFileName);              
