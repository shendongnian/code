    public virtual async Task<IEntity> Get(string id)
    {
        var parsedId;
        if (int.TryParse(id, out parsedId))
        {
            // It was an integer
        }
        else 
        {
            if (Guid.TryParse(id, out parsedId))
            {
                // It was a Guid
            }
            else 
            {
                // It was neither so what do you want to do?
            }
        }
    }
