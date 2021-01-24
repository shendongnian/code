    //some checkboxes
    CheckBox chkA = ...
    CheckBox chkB = ...
    CheckBox chkC = ...
    //Map each check box to its relevant property in Call
    var mapper = new Dictionary<CheckBox, Predicate<Call>>();
    mapper.Add(chkA, c => chkA.Checked && c.IsA);
    mapper.Add(chkB, c => chkB.Checked && c.IsB);
    mapper.Add(chkC, c => chkC.Checked && c.IsC);
    var callsData = ... //some enumerable of Calls
    var filteredCalls = callsData.Where(c => mapper[chkA](c) && mapper[chkB](c) && mapper[chkC](c));
