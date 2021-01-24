    var command = @"RESTORE FILELISTONLY FROM DISK = N'F:\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\Backup\Scratch.bak'";
    using (var sqlConnection = new SqlConnection("Server=localhost;Database=Scratch;Trusted_Connection=True;"))
    using (var sqlCommand = new SqlCommand(command, sqlConnection))
    {
        sqlConnection.Open();
        var sqlDataReader = sqlCommand.ExecuteReader();
        while (sqlDataReader.Read())
        {
            Console.WriteLine($"Logical Name: {sqlDataReader["LogicalName"]}");
            Console.WriteLine($"Physical Name: {sqlDataReader["PhysicalName"]}");
            Console.WriteLine($"Type: {sqlDataReader["Type"]}");
        }
    }
