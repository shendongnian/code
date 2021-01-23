    List<CableList> Runlist = new List<CableList>
    {
        new CableList { Location = new Location 
        { Facility = new Facility { FacilityTitle = "titel3"  }}},
        new CableList { Location = new Location 
        { Facility = new Facility { FacilityTitle = "titel2"  }}},
        new CableList { Location = new Location 
        { Facility = new Facility { FacilityTitle = "titel5"  }}},
        new CableList { Location = new Location 
        { Facility = new Facility { FacilityTitle = "titel1"  }}},
        new CableList { Location = new Location 
        { Facility = new Facility { FacilityTitle = "titel9"  }}}
    };
    System.Diagnostics.Debug.WriteLine("Before order:");
    foreach (var itm in Runlist)
        System.Diagnostics.Debug.WriteLine(itm.Location.Facility.FacilityTitle);
    var orderedResult =  Runlist.OrderBy(x => x.Location.Facility.FacilityTitle)
        .Skip(1)
        .Take(4)
        .ToList();
    System.Diagnostics.Debug.WriteLine("After order:");
    foreach (var itm in orderedResult)
        System.Diagnostics.Debug.WriteLine(itm.Location.Facility.FacilityTitle);
