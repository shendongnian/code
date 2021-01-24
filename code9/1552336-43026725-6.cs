    var results = primaryData.Select(pd => new {
        Id = pd.ID,
        PrimaryData = pd.PrimaryData,
        Extra = Tuple.Create("PhoneNumber", pd.tbList_DataText.Where(ld => ld.DataRowID == pd.ID && ld.ListColumnID == 1).Select(ld => ld.DataField).DefaultIfEmpty("").First())
    });
    // How to access:
    foreach (var result in results)
    {
        Console.WriteLine(result.Id);
        Console.WriteLine(result.PrimaryData);
        Console.WriteLine(result.Extra.Item1);
        Console.WriteLine(result.Extra.Item2);
    }
