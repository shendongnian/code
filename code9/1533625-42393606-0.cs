     private string Json(object anything)
     {
        return JsonConvert.SerializeObject(anything, Formatting.None, new JsonSerializerSettings()
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            ConstructorHandling = ConstructorHandling.Default,
            DateFormatHandling = DateFormatHandling.IsoDateFormat,//Before : MicrosoftDateFormat
            DefaultValueHandling = DefaultValueHandling.Ignore,
            NullValueHandling = NullValueHandling.Ignore,
            ObjectCreationHandling = ObjectCreationHandling.Replace,
            PreserveReferencesHandling = PreserveReferencesHandling.None,
            CheckAdditionalContent = false
        });
    }
