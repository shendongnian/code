    private static IEnumerable<char> Bomb(IEnumerable<char> text, List<int> indexes, int length)
    {
        return text.Select(
            (c, index) =>
            {
                if (c == ' ' && indexes.Contains(index % length) && index > length)
                {
                    indexes.Remove(index % length);
                }
                return !indexes.Contains(index % length) ? c : '\0';
            });
    }
