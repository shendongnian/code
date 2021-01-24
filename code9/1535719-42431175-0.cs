      var foo = from c in _uow.GetRepository<ChangeSet>().Entities.Where(expression) //Notice lambda exp here
        join o in _uow.GetRepository<ObjectChange>().Entities on c.Id equals o.ChangeSetId
        join p in _uow.GetRepository<PropertyChange>().Entities on o.Id equals p.ObjectChangeId
       select new
        {
            ChangeSetId = c.Id,
            Timestamp = c.Timestamp,
            User = c.User.DisplayName,  
            EntityType = o.TypeName,
            EntityValue = o.DisplayName,
            Property = p.PropertyName,
            OldValue = p.OriginalValue,
            NewValue = p.Value
        };
