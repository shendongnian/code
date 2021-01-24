    string match = "";
    foreach (var str in splitChar)
    {
        if (content.Contains(str)) 
        {
            match = str;
            break;
        }
    }
    if (!String.IsNullOrEmpty(match))
    {
        // Do whatever with `match`
    }
