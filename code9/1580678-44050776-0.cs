    // Open the file for output...
    ...
    
    // Loop over all the rows
    IEnumerable<Row> rowEnumerator = resultRequest.GetEnumerator();
    while (rowEnumerator.MoveNext()) {
        // Get the row
        Row r = rowEnumerator.Current;
    
        // Prepare a new line
        List<string> values = new List<string>;
    
        // Loop over all the columns of the row
        IEnumerator<Object> colEnumerator = r.GetEnumerator();
        while (colEnumerator.MoveNext()) {
            values.Add(...); // Stack the strings here 
        }
        // Create the row
        string line = String.Join(",", values.ToArray());
    
        // Output line to file
        // ...
    }
    // Close the file
    ...
