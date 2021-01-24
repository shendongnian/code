    PremiumContentRights.AllowPremiumContent = true;
    Foo foo = new Foo()
    {
        Id = 1,
        Name = "Hello",
        AlternateName = "World",
        ExtraContent = new PremiumStuff()
        {
            ExtraInfo = "For premium",
            SecretInfo = "users only."
        }
    };
    
    JsonSerializerSettings settings = new JsonSerializerSettings();
    settings.ContractResolver = new IncludePremiumContentAttributesResolver();
    settings.Formatting = Formatting.Indented;
    
    string json = JsonConvert.SerializeObject(foo, settings);
    
    Debug.WriteLine(json);
