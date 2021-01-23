    public IEnumerable<IList<string>> ProcessText(string input)
    {
        var lines = input.Split(new[] { Environment.NewLine });
        
        using (var enumerator = lines.GetEnumerator())
        {
            while (enumerator.MoveNext()
            {
                if (enumerator.Current == "-begin-"
                    yield return createSubList(enumerator).ToList();
            }
        }
    }
    private static IEnumerable<string> createSubList(IEnumerator<string> enumerator)
    {
        while (enumerator.MoveNext()
        {
            if (enumerator.Current == "-end-")
            {
                yield break;
            }
            if (!enumerator.Current.StartsWith(...whatever strings you want to ignore))
            {
                yield return enumerator.Current;
            }      
        }
    }
