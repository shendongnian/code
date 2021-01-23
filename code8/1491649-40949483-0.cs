    static IEnumerable<Tuple<int, int>> TwoAtATime(int min, int max, Random r)
    {
        var enumerator = Enumerable.Range(min, max - min + 1)
                                    .OrderBy(x=> r.Next()).GetEnumerator();
    
        while(enumerator.MoveNext())
        {
            int item1 = enumerator.Current;
            if (enumerator.MoveNext())
            {
                int item2 = enumerator.Current;
                yield return Tuple.Create(item1, item2);
            }
        }
    }
