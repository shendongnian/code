    public static string ToPrettyFormat(TimeSpan timeSpan)
    {
        var dayParts = new[] { GetDays(timeSpan), GetHours(timeSpan), GetMinutes(timeSpan) }
            .Where(s => !string.IsNullOrEmpty(s))
            .ToArray();
    
        var numberOfParts = dayParts.Length;
    
        string result;
        if (numberOfParts < 2)
            result = dayParts.FirstOrDefault() ?? string.Empty;
        else
            result = string.Join(", ", dayParts, 0, numberOfParts - 1) + " and " + dayParts[numberOfParts - 1];
    
        return result.UppercaseFirst();
    }
