    System.Reflection.Assembly a = System.Reflection.Assembly.GetExecutingAssembly();
    System.IO.Stream s = a.GetManifestResourceStream("<assemblyname>.<wavfilename>.wav");
    SoundPlayer player = new SoundPlayer(s);
    player.Play();
    Console.ReadLine();
