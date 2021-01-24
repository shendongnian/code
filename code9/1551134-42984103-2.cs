    StringBuilder sb = new StringBuilder();
    foreach (var node in collection)
    {
        // Omitted for brevity
        var stringToAdd = ...;
        // Append this item to the results
        sb.AppendLine(stringToAdd);   
    }
    
    // Store the results
    txtLog.Text = sb.ToString();
