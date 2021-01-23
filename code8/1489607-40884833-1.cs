    var music = new List<SoundPlayer>();
    //...
    //In your first loop, you would add the SoundPlayer object
    music.Add(sp);
    //.. 
    //Then when you're playing back:
    for (int k = 0; k < music.Count; k++)
    {
       music[k].PlaySync();
    }
