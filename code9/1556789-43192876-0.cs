    var lots = item.LotNum.Split('|');
    foreach (var lot in lots)
    {
        string vendor = string.Empty;
        if (lot.Contains("-"))
         vendor = lot.Substring(0, lot.IndexOf("-")).Trim();
    }
