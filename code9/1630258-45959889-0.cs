    Inventory inventory = new Inventory();
    
    //notice i'v added the 'u_borrower_id_email' property to your class:
    inventory.u_borrower_id_email = dict.GetStringOrDefault("u_borrower_id.phone");
    private static string GetStringOrDefault(this Dictionary<string, object> data, string key)
    {
        string result = "";
        object o;
        if (data.TryGetValue(key, out o))
        {
            if (o != null)
            {
                result = o.ToString();
            }
        }
        return result;
    }
