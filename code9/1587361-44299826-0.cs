    public override string ToString() 
    {
        var settings = new JsonSerializerSettings();
        settings.PreserveReferencesHandling = PreserveReferencesHandling.All;
        return JsonConvert.SerializeObject(this, settings);
    } 
