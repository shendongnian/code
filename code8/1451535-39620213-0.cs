    public static void UnTradeIdent(string tradeIdent, out string AccountIdent, out long OrderID, out string SubID)
    {
        TradeIdentData tradeIdentData = new TradeIdentData();
        var parts = tradeIdent.Split('!');
        AccountIdent = parts[0];
        if (parts[1].Contains("."))
        {
            var bits = parts[1].Split('.');
            OrderID = long.Parse(bits[1]);
            SubID = bits[1];
        }
        else
        {
            OrderID = long.Parse(parts[1]);
            SubID = "";
        }
    }
