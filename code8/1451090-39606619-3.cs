        // This assumes those column headers are above each line
        if (lines.Length >= 2)
        {
            // Get the string starting location of the [Status] column
            int index = lines[lines.Length - 2].IndexOf("Status");
    
            // Now replace the text under that Status Column in the next row
            // Remove the OK characters (first two)
            lines[lines.Length - 1] = lines[lines.Length - 1].Remove(index, 2);
            // Then Insert the two characters you want
            lines[lines.Length - 1] = lines[lines.Length - 1].Insert(index, "NG");
        }
 
