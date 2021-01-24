    if (!string.IsNullOrEmpty(input))
    {
        int tecIntermediate;
        if (int.TryParse(input, out tecIntermediate))
        {
            tec = tecIntermediate;
        }
        else
        {
            // handle the invalid output, you can default or notify the user.
        }
    }
