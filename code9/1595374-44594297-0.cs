    public void SetDepedencyForSymbol(string symbol)
    {
        string cmdText = "SELECT [Symbol] FROM [" + AccountCode + "].[FilledOrders] WHERE [Symbol] = '" + symbol + "'";
        OnChangeEventHandler handler = (sender, args) =>
        {
            string theSymbol = symbol;
            // Handle the event (for example, invalidate this cache entry).
        };
        using (SqlCommand command = new SqlCommand(cmdText, conn))
        {
            SqlDependency FilledDependency = new SqlDependency(command);
            FilledDependency.OnChange += handler;
            using (SqlDataReader reader = command.ExecuteReader())
            {
                // Process the DataReader.
            }
        }
    }
