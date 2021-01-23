    a = new ObservableCollection<Field>();
    abn = new FieldCount { Count = 0 };
    // note I assume you don't want to double initialize abn
    abn2 = new FieldCount { Count = 0 };
    // add fields to the collection
    a.Add(new Field { Name = "Field X", Yk = abn });
    a.Add(new Field { Name = "Field Y", Yk = abn });
    a.Add(new Field { Name = "Field Z", Yk = abn2 });
    a.Add(new Field());
