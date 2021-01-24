    static string CombineParts(string a, string b, char delimeter)
    {
        if (a == null) return b;
        if (b == null) return a;
        var combinedString = string.Empty;
        var partsOfA = a.Split(delimeter);
        var partsOfB = b.Split(delimeter);
        int i;
        for (i = 0; i < Math.Min(partsOfA.Length, partsOfB.Length); i++)
        {
            combinedString += $"{partsOfA[i]}{partsOfB[i]}{delimeter}";
        }
        // In case either string had more parts than the other, add them to the result
        if (i < partsOfA.Length)
        {
            combinedString += string.Join(delimeter.ToString(), partsOfA.Skip(i));
        }
        else if (i < partsOfB.Length)
        {
            combinedString += string.Join(delimeter.ToString(), partsOfB.Skip(i));
        }
        return combinedString.TrimEnd(',');
    }
