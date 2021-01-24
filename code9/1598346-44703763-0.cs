    string value = "9.999.999";
    StringBuilder sb = new StringBuilder(value);
    bool skippedLast = false;
    for (int i = sb.Length - 1; i >= 0; i--)
    {
        if (sb[i] == '.')
        {
            if (!skippedLast)
                skippedLast = true;
            else
                sb[i] = '\'';
        }
    }
    string desiredOutput = sb.ToString(); // 9'999.999
