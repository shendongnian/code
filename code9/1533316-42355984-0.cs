    var asm = System.Reflection.Assembly.LoadFrom("External.Resources.exe");
    var manifests = asm.GetManifestResourceNames();
    foreach (var s in manifests)
    {
        var rm = new ResourceManager(s, asm);
        var rs = rm.GetResourceSet(CultureInfo.CurrentCulture, true, true);
        foreach (DictionaryEntry r in rs)
        {
            Console.WriteLine(String.Format("Key: {0}\tValue{1}", r, r.Key, r.Value); 
        }
    }
