    private static IEnumerable<char> Bomb(IEnumerable<char> text, IEnumerable<int> indexes, int length)
    {
        var indexArray = new List<int>(indexes);
        var used = new object[length];
        return text.Select(
            (c, index) =>
                {
                    if (c != ' ' && indexArray.Contains(index % length))
                    {
                        used[index % length] = new object();
                        return '\0';
                    }
                    if (c == ' ' && used[index % length] != null)
                    {
                        indexArray.Remove(index % length);
                    }
                    return c;
                });
    }
