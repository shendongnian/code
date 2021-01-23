    FabricClient client = new FabricClient();
    try
    {
        await client.QueryManager.GetProvisionedFabricCodeVersionListAsync();
    }
    catch (FabricTransientException ex)
    {
        if (ex.ErrorCode == FabricErrorCode.CommunicationError)
        {
             // can't communicate with the cluster!
        }
    }
