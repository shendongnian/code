    var entity = (Entity)context.InputParameters["Target"];
    if (entity.LogicalName != "new_trialxrmservicetoolkit")
        return;
    var entityId=  entity.Id;
    ColumnSet myAttributes = new ColumnSet(new String[] { "new_LookupTransactionHeader" });
    Entity myEntityHavingLookup = service.Retrieve("new_trialxrmservicetoolkit", entityId, myAttributes);
    var myLookupId = ((Microsoft.Xrm.Sdk.EntityReference)(myEntityHavingLookup.Attributes["new_LookupTransactionHeader"])).Id;
    throw new InvalidPluginExecutionException(myLookupId.ToString());
