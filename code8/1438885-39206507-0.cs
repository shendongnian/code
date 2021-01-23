    Update(T entity,string[] includedFields)
    {
        var existingRecord = Context.Attach(entity); // assuming primary key (id) will be there in this entity
        var attachedEntry = Context.Entry(existingRecord);
        for(var field in includedFields)
        {
           attachedEntry.Property(field).IsModified = true;
        }
         
    }
