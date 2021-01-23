    private static IEnumerable<char> Bomb(IEnumerable<char> text, int[] indexes, int length)
    {
        var indexArray = new List<int>(indexes);
        return text.Select(
            (c, index) =>
                {
                    if (c == ' ' && indexArray.Contains(index % length) && (index % length) > length)
                    {
                        indexArray.Remove(index % length);
                    }
                    return !indexArray.Contains(index % length) ? c : '\0';
                });
    }
