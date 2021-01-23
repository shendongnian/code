    public IEnumerable<string> createSubList(IEnumerator<string> enumerator)
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
