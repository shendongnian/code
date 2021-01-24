        var assembly = typeof(App).GetTypeInfo().Assembly;
        var MyAssemblyName = assembly.GetName().Name; //now this is for the future
        //if you want acces files by a generated name would be:
        // MyAssemblyName + ".Music."+filename
        //anyway now we are building the whole list:
        var MusicFiles = new List<string>(); //todo change to your music class 
        foreach (var res in assembly.GetManifestResourceNames())
        {
            if (res.Contains(".track"))
            {
                MusicFiles.Add(res);
            }
        }
