    public static SteroController GenerateStereo(StereoBrand brand)
    {
        SteroController stereo = null;
        var type = typeof(IStereo);
        var types = AppDomain.CurrentDomain.GetAssemblies()//Find all classes which implemented ISereo
            .SelectMany(s => s.GetTypes())
            .Where(p => type.IsAssignableFrom(p)).ToList();
        foreach(Type t in types)
        {
            var stereoNameProp = t.GetProperties().SingleOrDefault(p => p.Name == "StereoName");//Get stereo name prop
            if (stereoNameProp != null && stereoNameProp.GetValue(t).ToString() == brand.ToString())//Check it with brand name
                stereo =(SteroController)Activator.CreateInstance(type);//Make an instance
        }  
        return stereo;
    }
