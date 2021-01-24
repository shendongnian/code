    dbContext.Set<entity>().Attach(entity);
    if (typeFromCombobox.Id == 0){
        //new type added
        dbContext.Set<type>().Add(typeFromCombobox)
    }
    entity.type = typeFromCombobox;
    dbContext.SaveChanges()
