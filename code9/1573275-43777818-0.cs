    public IEnumerable<string> ProcessText(string txtInput)
    {
        IEnumerable<string> GetNextNLines(IEnumerator<string> enumerator, int n)
        {
            var counter = 0;
            while (counter < n && enumerator.MoveNext())
            {
                 yield return enumerator.Current;
                 counter += 1;
            }
            if (counter != n) //consider throwing with an unexpected format message.
        }
        using (var enumerator = File.ReadLines(txtInput).GetEnumerator())
        {
            while (enumerator.MoveNext())
            {
                if (enumerator.Current.Constains("Line1"))
                {
                    yield return enumerator.Current;
                    
                    foreach (var line in GetNextNLines(enumerator, 2)
                    {
                        yield return line;
                    }
                } 
            }
        }
    }
