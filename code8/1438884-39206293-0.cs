    Update(int id, T entity,string[] excludedFields)
    {
        var existingRecord = Get(id); //Gets entity from db based on passed id
         if (existingRecord != null)
         {
              var attachedEntry = Context.Entry(existingRecord);
              attachedEntry.CurrentValues.SetValues(entity);
              for(var field in excludedFields)
              {
                   attachedEntry.Property(field).IsModified = false;
              }
         }
    }
