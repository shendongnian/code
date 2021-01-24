    using(System.Media.SoundPlayer Player = new System.Media.SoundPlayer())
    {
       string file = @"C:\Windows\Media\tada.wav";
       try
       {
           Player.SoundLocation = file;
           Player.Play();
       }
       catch (Exception ex)
       {
           throw ex;
       }
    }
