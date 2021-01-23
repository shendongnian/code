    public static bool UnTradeIdent(string tradeIdent, out string AccountIdent, out long OrderID, out string SubID)
    {
        bool result = false;
        try
        {
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
        catch(ArgumentNullException ane)
        {
            // Handle parsing exception
            AccountIdent = "";
            OrderID = 0;
            SubID = "";
        }
        catch (FormatException fe)
        {
            // Handle parsing exception
            AccountIdent = "";
            OrderID = 0;
            SubID = "";
        }
        catch (OverflowException oe)
        {
            // Handle parsing exception
            AccountIdent = "";
            OrderID = 0;
            SubID = "";
        }
        return result;
    }
