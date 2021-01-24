    _uow.GetRepository<ChangeSet>().Entities
        .Where(expression)
    .Join(_uow.GetRepository<ObjectChanges>().Entities, cs => cs.Id, oc => oc.ChangeSetId, 
        (cs, oc) => new { cs, oc })
    .Join(_uow.GetRepository<PropertyChanges>().Entities, outer => outer.oc.Id, pc => pc.ObjectChangeId, 
        (outer, pc) => new { cs = outer.cs, oc = outer.cs, pc })
    .Join(_uow.GetRepository<User>().Entities, outer => outer.cs.Author_Id, u => u.Id, 
        (outer, u) => new { 
            ChangeSetId = outer.cs.Id,
            Timestamp = outer.cs.Timestamp,
            User = u.DisplayName,  
            EntityType = outer.oc.TypeName,
            EntityValue = outer.oc.DisplayName,
            Property = outer.pc.PropertyName,
            OldValue = outer.pc.OriginalValue,
            NewValue = outer.pc.Value
        })
