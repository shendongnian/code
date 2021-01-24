    var results = primaryData.Select(pd => {
        dynamic result = new System.Dynamic.ExpandoObject();
        result.Id = pd.ID;
        result.PrimaryData = pd.PrimaryData;
        
        // Choose one of the following. Since you only "PhoneNumber" at runtime, probably the second one.
        result.PhoneNumber = pd.tbList_DataText.Where(ld => ld.DataRowID == pd.ID && ld.ListColumnID == 1).Select(ld => ld.DataField).DefaultIfEmpty("").First();
        ((IDictionary<string, object>)result).Add("PhoneNumber", pd.tbList_DataText.Where(ld => ld.DataRowID == pd.ID && ld.ListColumnID == 1).Select(ld => ld.DataField).DefaultIfEmpty("").First());
        return result;
    });
    // How to access:
    foreach(var result in results)
    {
        Console.WriteLine(result.Id);
        Console.WriteLine(result.PrimaryData);
        // Both work, independently how you created them
        Console.WriteLine(result.PhoneNumber);
        Console.WriteLine(((IDictionary<string, object>)result)["PhoneNumber"]);
    }
