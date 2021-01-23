    else
    {
        Debug.Assert(parameterDescriptor == null);
    
        // If parameterDescriptor is null, this is an undeclared route parameter which only occurs
        // when source is FromUri. Ignored in request model and among resource parameters but listed
        // as a simple string here.
        ModelDescription modelDescription = modelGenerator.GetOrCreateModelDescription(typeof(string));
        AddParameterDescription(apiModel, apiParameter, modelDescription);
    }
