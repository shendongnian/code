    public void playMyAudio(AudioClip clipToPlay)
    {
        SoundPlayer2D.clip = clipToPlay;
        SoundPlayer2D.Play();
    }
    
    public void stopMyAudio()
    {
        SoundPlayer2D.clip = sound;
        SoundPlayer2D.Stop();
    }
