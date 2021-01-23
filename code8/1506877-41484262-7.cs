    public Thing Get(int id) {
        Thing thing = GetThingFromDB();
        if (thing == null)
            throw new StatusCodeException(HttpStatusCode.NotFound);
        return thing;
    }
