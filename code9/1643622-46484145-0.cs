    [Benchmark]
    public static void Enumerator()
    {
        using (var enumerator1 = Type1S.GetEnumerator())
        {
            using (var enumerator2 = Type2S.GetEnumerator())
            {
                while (enumerator1.MoveNext() && enumerator2.MoveNext())
                {
                    enumerator1.Current.Value += enumerator2.Current.Val;
                }
            }
        }
    }
