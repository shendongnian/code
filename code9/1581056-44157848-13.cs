    //Fire event when the video starts
    private void SetProgresMax(object sender, VlcMediaPlayerPlayingEventArgs e)
    {
       Invoke(new Action(() =>
       {
           trackBar1.Value = trackBar1.Minimum;
           var vlc = (VlcControl)sender;
           trackBar1.Maximum = (int)vlc.Length / 1000;
           a = (int)vlc.Length / 1000; // Length (s)
           c = a / 60; // Length (m)
           a = a % 60; // Length (s)
           label1.Text = 0 + "/" + c+":"+a; 
       }));
