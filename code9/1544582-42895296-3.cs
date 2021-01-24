    list.AddLast(tx);
    while (list.First.Value.Timestamp < DateTime.Now.Subtract(buffering))
    {
        list.RemoveFirst();
    }
    o.OnNext(list.Select(tx2 => tx2.Value).ToArray());
