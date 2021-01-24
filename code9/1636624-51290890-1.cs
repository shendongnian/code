    var thing = context.Things.Find(id);
    if (thing.ShouldBeSentToService) {
        TriggerExternalServiceAndWait(id);
    
        // Detach the object to remove it from context’s cache.
        context.Entities(thing).State = EntityState.Detached;
    
        // Then load it. We will get a new object with data
        // freshly loaded from the database.
        thing = context.Things.Find(id);
    }
    UseSomeOtherData(thing.DataWhichWasUpdated);
