    for (int i = 0; i < sLines.Count(); i++)
    {
        if (sLines[i].SValue == "")
        {
            Value = LastSValue;
        }
        else
        {
            Value = (sLines[i].SValue);
            LastSValue = Value;
        }
        // use Value
    }
