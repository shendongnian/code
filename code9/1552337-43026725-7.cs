    // Using C# 6 notation
    var results = primaryData.Select(pd => new Dictionary<string, object>{
        ["Id"] = pd.ID,
        ["PrimaryData"] = pd.PrimaryData,
        ["PhoneNumber"] = pd.tbList_DataText.Where(ld => ld.DataRowID == pd.ID && ld.ListColumnID == 1).Select(ld => ld.DataField).DefaultIfEmpty("").First()
    });
    // Using C# 5 notation
    var results = primaryData.Select(pd => new Dictionary<string, object>{
        {"Id", pd.ID},
        {"PrimaryData", pd.PrimaryData},
        {"PhoneNumber", pd.tbList_DataText.Where(ld => ld.DataRowID == pd.ID && ld.ListColumnID == 1).Select(ld => ld.DataField).DefaultIfEmpty("").First()}
    });
    // How to access:
    foreach(var result in results)
    {
        Console.WriteLine(result["Id"]);
        Console.WriteLine(result["PrimaryData"]);
        Console.WriteLine(result["PhoneNumber"]);
    }
