    a = new ObservableCollection<Field>();
    abn = new Field { Count = 0 };
    // note I assume you don't want to double initialize abn
    abn2 = new Field { Count = 0 };
    // add fields to the collection, create new field if no existing one is used
    a.Add(abn);
    a.Add(abn);
    a.Add(abn2);
    a.Add(new Field());
