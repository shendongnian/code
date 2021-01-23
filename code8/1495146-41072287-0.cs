    try
    {
        adapter.SelectCommand = new OleDbCommand(query, conn);
        adapter.InsertCommand = new OleDbCommand("INSERT INTO Account (AccountNumber, LastName, FirstName, CurrentBalance) " +
        "VALUES (?, ?, ?, ?)", conn);
        adapter.DeleteCommand = new OleDbCommand(query, conn);
        OleDbCommandBuilder builder = new OleDbCommandBuilder(adapter);
        adapter.Update(Account);
        Console.WriteLine("Saved");
    }
    catch
    {
    }
