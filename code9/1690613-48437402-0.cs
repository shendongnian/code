    var iter = users.GetEnumerator();
    using(iter as IDisposable)
    {
        while(iter.MoveNext())
        {
            var user = (MemberUser)iter.Current;
            // ...
        }
    }
