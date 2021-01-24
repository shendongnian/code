    using System.Windows.Media;
    
    public void PlaySound(string filename)
    {
    	var mplayer = new MediaPlayer();
    	mplayer.MediaEnded += new EventHandler(MediaEndedHandler);
        mplayer.Open(new Uri(filename));
        mplayer.Play();
    }
    
    public void MediaEndedHandler(object sender, EventArgs e)
    {
    	((MediaPlayer)sender).Close();
    }
