     public static string Path
            {
                get
                {
                    switch (Application.platform)
                    {
                        case RuntimePlatform.IPhonePlayer:
                            return Path.Combine(Application.persistentDataPath, "MyStuff");
    
                        case RuntimePlatform.Android:
                            return Path.Combine(Application.temporaryCachePath, "MyStuff");
    
                        default:
                            return Path.Combine(Directory.GetParent(Application.dataPath).FullName, "MyStuff");
                    }
                }
            }
