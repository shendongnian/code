    public async Task<IActionResult> DownloadFile(Guid FileId)
    {
        var connection = new SqlConnection(DatabaseService.ConnectionString);
        HttpContext.Response.RegisterForDispose(connection);
        await connection.OpenAsync();
        var command = connection.CreateCommand();
        HttpContext.Response.RegisterForDispose(command);
        command.CommandText = "select FileName, FileContent from Files where FileId=@FileId";
        command.CommandType = System.Data.CommandType.Text;
        command.Parameters.AddWithValue("@FileId", FileId);
        var reader = await command.ExecuteReaderAsync(System.Data.CommandBehavior.SequentialAccess | System.Data.CommandBehavior.SingleRow);
        HttpContext.Response.RegisterForDispose(reader);
        if (!await reader.ReadAsync())
            return NotFound();
        var attachmentName = Convert.ToString(reader[0]);
        var stream = reader.GetStream(1);
        HttpContext.Response.RegisterForDispose(stream);
        var response = File(stream, "application/octet-stream", attachmentName);
        return response;
    }
