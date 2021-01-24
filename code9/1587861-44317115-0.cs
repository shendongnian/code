    List<System.Windows.Media.MediaPlayer> sounds = new List<System.Windows.Media.MediaPlayer>();
    private void playSound(string name)
    {
        string url = Application.StartupPath + "\\notes\\" + name + ".wav";
        var sound = new System.Windows.Media.MediaPlayer();
        sound.Open(new Uri(url));
        sound.play();
        sounds.Add(sound);
    }
    private void stopSound()
    {
        for (int i = sounds.Count - 1; i >= 0; i--)
        {
            sounds[i].Stop();
            sounds.RemoveAt(i);
        }
    }
