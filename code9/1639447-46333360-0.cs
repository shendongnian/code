    using System.Windows.Media;
    
    public void PlaySound(string filename)
    {
    	var mplayer = new MediaPlayer();
    	mplayer.MediaEnded += new EventHandler(MediaEndedHandler);
    }
    
    public void MediaEndedHandler(object sender, EventArgs e)
    {
    	((MediaPlayer)sender).Close();
    }
