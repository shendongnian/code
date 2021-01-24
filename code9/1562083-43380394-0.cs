    private static IEnumerable<string> GetVertexCoordinates(string fileName)
    {
        var enumerator = File.ReadLines(fileName).GetEnumerator();
        while (enumerator.MoveNext())
        {
            if (enumerator.Current == "VERTEX")
            {
                yield return enumerator.Current;
                for (var i = 0; i < 6; i++) enumerator.MoveNext(); // skip 6 lines
                yield return enumerator.Current; 
                for (var i = 0; i < 2; i++) enumerator.MoveNext(); // skip 2 more lines
                yield return enumerator.Current;
            }
        }
    }
