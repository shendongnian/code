    List<GetReturnObject> results = RestUtils.GetReturnObjects();
    using (JsConfig.CreateScope("EmitCamelCaseNames:false"))
    {
        var s = JsonSerializer.SerializeToString(results);
    }
