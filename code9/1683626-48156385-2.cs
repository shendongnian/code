    var errorMessage = new StringBuilder();
    if (missingTables.Any())
    {
        errorMessage.AppendLine("Missing Tables: " + string.Join(", ", missingTables));
    }
    if (extraTables.Any())
    {
        errorMessage.AppendLine("Extra Tables: " + string.Join(", ", extraTables));
    }
