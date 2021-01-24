    string baseQuery = "INSERT INTO orders (id, dt, amount, product_id ) VALUES(";
    string[] lines = System.IO.File.ReadAllLines(@"e:\temp\orders.txt");
    // Skip the first line
    for (int i = 1; i < lines.Length; i++)
    {
    	string[] elements = lines[i].Split(delimiterChars);
        // Keep the parameter names in a list to get an easy way to 
        // concatenate them all together at the end of the loop
    	List<string> text = new List<string>();
    	for (int j = 0; j < elements.Length; j++)
    	{
    	    text.Add("@VALUE" + j);
    	    cmd.Parameters.AddWithValue("@VALUE" + j, elements[j]);
    	}
        // Create the command text in a single shot
    	cmd.CommandText = baseQuery + string.Join(",", text) + ")";
    	try
    	{
    	    cmd.ExecuteNonQuery();
    	}
    	catch (Exception ex)
    	{
    	    Console.WriteLine("Caught exception: " + ex.Message);
    	}
    }
