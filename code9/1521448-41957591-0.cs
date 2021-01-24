    Dictionary<int, string> loDicOriginal = new Dictionary<int, string>();
    Dictionary<int, string> loDicEdit = new Dictionary<int, string>();
    
    loDicOriginal.Add(1, "int 1 list 1");
    loDicOriginal.Add(2, "int 2 list 1");
    loDicOriginal.Add(3, "int 3 list 1");
    
    loDicEdit.Add(1, "int 1 list 2");
    loDicEdit.Add(3, "int 3 list 2");
    
    var loQuery = loDicOriginal.Join(loDicEdit, 
        dicOrg => dicOrg.Key, 
        dicEdit => dicEdit.Key, 
        (entryOrg, entryEdit) => new { Original = entryOrg, Edit = entryEdit });
    
    foreach (var loOut in loQuery)
    {
        System.Diagnostics.Debug.WriteLine("{0}->{1} | {2}->{3}", loOut.Original.Key, loOut.Original.Value, loOut.Edit.Key, loOut.Edit.Value);
    }
