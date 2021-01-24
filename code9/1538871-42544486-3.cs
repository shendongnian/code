    var groups = client.GetAllOperatorGroups()
    var model = new PermissionsVM();
    model.Headings = groups.Select(x => String.Format("{0} {{1})", x.GROUPNAME, x.GROUPID));
    foreach (var func in Enum.GetValues(typeof(EnFunction)).Cast<EnFunction>())
    {
        RightsVM r = new RightsVM();
        r.Right = func;
        foreach (var g in groups)
        {
            GroupRightsVM gr = new GroupRightsVM();
            gr.GroupID = g.GROUPID;
            gr.IsSelected = ...
            r.Groups.Add(gr);
        }
        model.Persmissions.Add(r);
    }
    return View(model);
