    // Create array of integers with the same size as the array of parts
    int[] grades = new int[parts.Length];
    // Loop through the input parts and convert them into integers
    for(i=0; i<parts.Length; i++)
    {
        // Use `TryParse()` as it wont throw an Exception if the inputs are invalid
        int.TryParse(parts[i], out grades[i]);
    }
