    public static string TradeIdentToAccountIdent(string tradeIdent)
    {
        var parts = tradeIdent.Split('!');
        return parts[0];
    }
    public static long TradeIdentToOrderID(string tradeIdent)
    {
        var parts = tradeIdent.Split('!');
        if (parts[1].Contains("."))
        {
            var bits = parts[1].Split('.');
            
            return long.Parse(bits[1]); // Taken from your example, should probably be bits[0]?
        }
        else
            return long.Parse(parts[1]);
    }
