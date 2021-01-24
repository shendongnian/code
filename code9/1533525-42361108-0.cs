    List<string> productNames = new List<string>() { "A", "B", "C" };
    var parameters = new string[productNames.Count];
    var cmd = new SqlCommand();
    for (int i = 0; i < items.Length; i++)
    {
        parameters[i] = string.Format("@name{0}", i);
        cmd.Parameters.AddWithValue(parameters[i], items[i]);
    }
    
    cmd.CommandText = string.Format("SELECT * FROM products WHERE LOWER(name) IN ({0})", string.Join(", ", parameters));
    cmd.Connection = new SqlConnection(connStr);
