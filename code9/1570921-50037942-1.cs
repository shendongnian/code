    StyleDetail styleNew = new StyleDetail() { Id = "12", Code = "first" };
    StyleDetail styleOld = new StyleDetail() { Id = "23", Code = "second" };
    var diff = ObjectDiffPatch.GenerateDiff (styleOld , styleNew );
    
    // original properties values
    Console.WriteLine (diff.OldValues.ToString());
    
    // updated properties values
    Console.WriteLine (diff.NewValues.ToString());
