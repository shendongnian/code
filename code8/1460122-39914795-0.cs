    var assembly = Assembly.GetExcetutingAssembly();
    string name = "namehere";
    using (Stream stream = assembly.GetManifestResourceStream(name))
    {
        SoundPlayer myNewSound = new SoundPlayer(stream);
        myNewSound.Load();
        myNewSound.Play();
    }
