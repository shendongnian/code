    int number = 0;
    var listOfBoth = new List<OldAndNew>();
                var x = AdOld.Select(y => new OldAndNew()
                {
                    NewPK = number++,
                    OriginalPK = y.PK,
                    Text = y.Text
                });
                var y = AdNew.Select(y => new OldAndNew()
                {
                    NewPK = number++,
                    OriginalPK = y.PK,
                    Text = y.Text
                });
    listOfBoth.Add(x);
    listOfBoth.Add(y);
