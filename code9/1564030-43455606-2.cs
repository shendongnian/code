    var info = item.GetType().GetProperty(p.Key);
    var value = info.GetValue(item);
    var normalized = (double) value;
    
    if (normalized == 0.0)
    {
        normalized = 0.0;
    }
    
    var bytes = BitConverter.GetBytes(normalized);
