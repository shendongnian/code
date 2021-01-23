    int someValue = -1;
    if (Int32.TryParse(row.Cells[3].Value.ToString(), someValue))
    {
        // Definitely an integer
        // Perform additional validation... someValue >= 0, etc.
    }
    else
    {
        // Not an integer
    }
