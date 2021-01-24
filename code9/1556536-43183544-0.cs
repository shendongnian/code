    var sb = new StringBuilder();
    foreach (var inner in x.InnerExceptions)
    {
        sb.AppendLine(inner.ToString());
    }
    System.Diagnostics.Debug.Print(sb.ToString()); 
