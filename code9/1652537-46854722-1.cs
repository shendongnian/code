    var csvPath = @"f:\public\temp\temp.csv";
    var entriesUpdated = 0;
    // Order the list so we match on the most similar match (ABC.DEF before ABC)
    var orderedTags = ValidTags.OrderByDescending(t => t);
    var newFileLines = new List<string>();
    // Read each line in the file
    foreach (var csvLine in File.ReadLines(csvPath))
    {
        // Get the columns
        var columns = csvLine.Split(',');
        // Process each column
        for (int index = 0; index < columns.Length; index++)
        {
            var column = columns[index];
            switch (index)
            {
                case 0: // tag column
                    var correctTag = orderedTags.FirstOrDefault(tag =>
                        column.IndexOf(tag, StringComparison.OrdinalIgnoreCase) > -1);
                    if (correctTag != null)
                    {
                        // This item contains a correct tag, so 
                        // update it if it's not an exact match
                        if (column != correctTag)
                        {
                            columns[index] = correctTag;
                            entriesUpdated++;
                        }
                    }
                    else
                    {
                        // This column does not contain a correct tag, so mark it as invalid
                        columns[index] += "-invalid";
                        entriesUpdated++;
                    }
                    break;
                // Other cases for other columns follow if needed
            }
        }
        newFileLines.Add(string.Join(",", columns));
    }
    // Write the new lines if any were changed
    if (entriesUpdated > 0) File.WriteAllLines(csvPath, newFileLines);
