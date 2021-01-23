    public static void MapAircraftInformation(ModelName inContext, ModelName outOfContext)
    {
        inContext.ID = outOfContext.ID;
        inContext.stringProperty= outOfContext.stringProperty;
        inContext.OwnerID = outOfContext.OwnerID; \\ foreign key
        inContext.DateCreated = outOfContext.DateCreated;
    }
