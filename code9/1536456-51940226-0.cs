    public async Task BindModelAsync(ModelBindingContext BindingContext)
    {
        // Read HTTP header.
        string headerName = BindingContext.FieldName;
        if (BindingContext.HttpContext.Request.Headers.ContainsKey(headerName))
        {
            StringValues headerValues = BindingContext.HttpContext.Request.Headers[headerName];
            if (headerValues == StringValues.Empty)
            {
                // Value not found in HTTP header.  Substitute empty GUID.
                BindingContext.ModelState.SetModelValue(BindingContext.FieldName, headerValues, Guid.Empty.ToString());
                BindingContext.Result = ModelBindingResult.Success(Guid.Empty);
            }
            else
            {
                // Value found in HTTP header.
                string correlationIdText = headerValues[0];
                BindingContext.ModelState.SetModelValue(BindingContext.FieldName, headerValues, correlationIdText);
                // Parse GUID.
                BindingContext.Result = Guid.TryParse(correlationIdText, out Guid correlationId)
                    ? ModelBindingResult.Success(correlationId)
                    : ModelBindingResult.Failed();
            }
        }
        else
        {
            // HTTP header not found.
            BindingContext.Result = ModelBindingResult.Failed();
        }
        await Task.FromResult(default(object));
    }
