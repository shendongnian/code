    var query = ctx.ChangeSets
        .SelectMany(x => x.ObjectChanges, (a, oc) => new
        {
            ChangeSetDescription = a.Description,
            ObjectChangeDescription = oc.Description
        ,
            Pcs = oc.PropertyChanges
        })
        .SelectMany(x => x.Pcs, (a, pc) => new
        {
            ChangeSetDescription = a.ChangeSetDescription,
            ObjectChangeDescription = a.ObjectChangeDescription,
            PropertyChangeDesription = pc.Description
        });
    var result = query.ToList();
