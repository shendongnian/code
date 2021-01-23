    public static void MapModelName(ModelName inContext, ModelName outOfContext)
    {
        inContext.ID = outOfContext.ID;
        inContext.stringProperty= outOfContext.stringProperty;
        inContext.OwnerID = outOfContext.OwnerID; \\ foreign key
        inContext.DateCreated = outOfContext.DateCreated;
    }
