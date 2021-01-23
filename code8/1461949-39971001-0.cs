    // This will set the state of the main entity and all of it's navigational 
    // properties as `Added` or `Modified`.
    context.InsertOrUpdateGraph(user)
           .After(entity =>
           {
                // And this will delete missing UserMusicType objects.
                entity.HasCollection(p => p.Music)
                   .DeleteMissingEntities();
           });  
