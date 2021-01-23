    public void Edit(TBusinessObject entity)
            {
            var originalEntity = context.Set<TBusinessObject>().AsNoTracking().FirstOrDefault(r => r.Id.Equals(entity.Id));
            EntityEntry<TBusinessObject> original = context.Entry(originalEntity);
            EntityEntry<TBusinessObject> client = context.Entry(entity);
            foreach (var property in original.OriginalValues.Properties)
            {
                var dbMember = original.Member(property.Name);
                var clientMember = client.Member(property.Name);
                if(!property.IsPrimaryKey())
                {
                    dbMember.CurrentValue = clientMember.CurrentValue;
                    dbMember.IsModified = true;
                }
            }
            context.Update(originalEntity);
            context.SaveChanges(true);
        }
