    try
    {
        JsonConvert.DeserializeObject<Account>(json, new JsonSerializerSettings
        {
            MissingMemberHandling = MissingMemberHandling.Error
        });
    }
    catch (JsonSerializationException ex)
    {
        Console.WriteLine(ex.Message);
        // Could not find member 'DeletedDate' on object of type 'Account'. Path 'DeletedDate', line 4, position 23.
    }
