    private bool IsRotation(string a, string b)
    {
        if (a.Length != b.Length) { return false; }
        for (int i = 0; i < b.Length; ++i)
        {
            if (GetCharactersLooped(b, i).SequenceEqual(a))
            {
                return true;
            }
        }
        return false;
    }
    private IEnumerable<char> GetCharactersLooped(string data, int startPos)
    {
        for (int i = startPos; i < data.Length; ++i)
        {
            yield return data[i];
        }
        for (int i = 0; i < startPos; ++i)
        {
            yield return data[i];
        }
    }
