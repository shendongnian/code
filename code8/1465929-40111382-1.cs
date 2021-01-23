    [HandleProcessCorruptedStateExceptions]
    private static void StartTable(Table table) {
        try
        {
            table.Start();
        }
        catch (AccessViolationException)
        {
            // Ignore
        }
    }
