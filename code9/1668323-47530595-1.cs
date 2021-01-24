    public class Form1 : Form
    {
        WMPLib.WindowsMediaPlayer Player;
        String m_Directory;
    
        public Form1(String directory)
        {
            m_Directory = directory;
        }
        
        private void PlayFile(String url)
        {
            Player = new WMPLib.WindowsMediaPlayer();
            Player.PlayStateChange += 
                new WMPLib._WMPOCXEvents_PlayStateChangeEventHandler(Player_PlayStateChange);
            Player.MediaError += 
                new WMPLib._WMPOCXEvents_MediaErrorEventHandler(Player_MediaError);
            Player.URL = url;
            Player.controls.play();
        }
        
        private void Form1_Load(object sender, System.EventArgs e)
        {
            var di = new DirectoryInfo(m_Directory);
            var files = di.GetFiles("*.*").Where(f => f.Extension.ToLowerInvariant() == ".wma");
            
            Random random = new Random();
            var file = files.ElementAt(random.Next(0,files.Count())).FullName;
    
            PlayFile(file);
        }
        
        private void Player_PlayStateChange(int NewState)
        {
            if ((WMPLib.WMPPlayState)NewState == WMPLib.WMPPlayState.wmppsStopped)
                this.Close();
        }
        
        private void Player_MediaError(object pMediaObject)
        {
            MessageBox.Show("Cannot play media file.");
            this.Close();
        }
    }
