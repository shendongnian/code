    public static IEnumerable<string> GetTextValues(IEnumerable<string> textNames)
    {
        if (textNames == null)
            return Enumerable.Empty<string>();
            // or consider: throw ArgumentNullException(nameof(textNames));
        return textNames.Select(textName => GetValue(textName));
    }
