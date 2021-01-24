    string query = @"Update Table SET ";
    IEnumerable<string> assignments = new string[]
    {
        SetField(command, "Field1", "@var1", var1),
        SetField(command, "Field2", "@var2", var2),
        SetField(command, "Field3", "@var3", var3),
    };
    assignments = assignments.Where(s => s != null).ToList();
    if (!assignments.Any())
        return;              // no update needed
    query += string.Join(",", assignments);
