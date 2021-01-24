    private System.Windows.Media.MediaPlayer playSound (string path)
    {
        if (System.IO.File.Exists(path))
        {
           System.Windows.Media.MediaPlayer mp = new System.Windows.Media.MediaPlayer();
           mp.Open(new System.Uri(path));
           mp.Play();
           return mp;
        }
        return null;
    }
