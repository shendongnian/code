    var complexList = ColourLists.ComplexList;
    var simpleList  = ColourLists.SimpleList;
    var productName = "iPad Pro(9.7) 32GB in Rose Gold";
    var productColour = string.Empty;
    foreach(var colour in complexList)
    {
        if(productName.Contains(colour, StringComparison.Ordinal))
        {
            productColour = colour;
            break;
        }
    }
    if(string.IsNullOrEmpty(productColour))
    {
        foreach (var colour in simpleList)
        {
            if (productName.Contains(colour, StringComparison.Ordinal))
            {
                productColour = colour;
                break;
            }
        }
    }
