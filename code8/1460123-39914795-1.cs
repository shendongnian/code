    var assembly = Assembly.GetExcetutingAssembly();
    string name = "Namespace.Sound.wav";
    using (Stream stream = assembly.GetManifestResourceStream(name))
    {
        SoundPlayer myNewSound = new SoundPlayer(stream);
        myNewSound.Load();
        myNewSound.Play();
    }
