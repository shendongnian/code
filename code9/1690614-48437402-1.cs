    using(var iter = users.GetEnumerator())
    {
        while(iter.MoveNext())
        {
            var user = iter.Current;
            // ...
        }
    }
