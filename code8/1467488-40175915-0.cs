    try
    {
        using (var tx = StateManager.CreateTransaction())
        {
            await dictionary.AddOrUpdateAsync(tx, dto.Id, dto, (key, _) => dto);
            await transaction.CommitAsync();
        }
    }
    catch (FabricObjectClosedException ex)
    {
        ServiceEventSource.Current.Message(ex.ToString());
        throw; // Pass the exception up as we only log it here.
    }
