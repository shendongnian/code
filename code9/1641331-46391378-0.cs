    bool ContainsAny(string haystack, IEnumerable<string> needles, out which)
    {
        foreach(var s in needles)
        {
            if (haystack.Contains(s))
            {
                which = s;
                return true;
            }
        }
        which = null;
        return false;
    }
