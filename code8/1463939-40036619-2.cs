    var builder = new StringBuilder();
    foreach(var part in enumerable.Select(v => v.TheInterestingStuff))
    {
        builder.Append(", ");
        builder.Append("[");
        builder.Append(part);
        builder.Append("]");
    }
    builder.Remove(0, 2); //Remove first comma and space
