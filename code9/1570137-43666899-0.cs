    List<Package> packages = new List<Package>();
    // add your packages here ...
    
    List<Dictionary<string, object>> shipments = new List<Dictionary<string, object>>();
    foreach(var p in packages){
        shipments.Add(new Dictionary<string, object>() {
              {"parcel", 
               new Dictionary<string, object>() {
                   { "predefined_package", "MediumFlatRateBox" },  
                   { "weight", p.Weight }}}
                });
    }
