    SoundPlayer sp = new SoundPlayer();
    foreach(var note in music)
    {
        sp.SoundLocation = note;
        bool everythingIsFine = false;
        // Logic for everythingIsFine;
        if(everythingIsFine){
            sp.PlaySync(); 
        }
    }
