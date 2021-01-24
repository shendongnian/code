    List<string> all = new List<string>() { "Consultant", "QA Manager", "HR Manager", "Database Manager", "Architect", "Project Manager", "Project Coordinator" };
    var filter = "Project Manager";
    var filterList = filter.Trim().Split(' ');
    List<string> matchProfiles = new List<string>();
    foreach (string filt in filterList)
    {
        matchProfiles.AddRange(all.Where(o => o.Contains(filt) && !matchProfiles.Contains(o)));
    }
    //Result: "Project Manager,Project Coordinator,QA Manager,HR Manager,Database Manager"
