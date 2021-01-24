    public class Player : IDisposable
    {                      
    public bool IsOpen
    {
        get; private set;
    }
    ///You have to return a task to run this code asynchronously
    public Task Open(string fileName)
    {
            // close previous file
            Close();
            mediaPlayer = new MediaPlayer();
            mediaPlayer.ScrubbingEnabled = true;
            mediaPlayer.MediaOpened += MediaPlayer_MediaOpened;
           
            return Task.Run(mediaPlayer.Open(new Uri(fileName)));
    }
    /// <summary>
    /// Fires when the MediaPlayer has finished opening.
    /// </summary>
    private void MediaPlayer_MediaOpened(object sender, EventArgs e)
    {
        totalMilliseconds = mediaPlayer.NaturalDuration.TimeSpan.TotalMilliseconds;
        //40.00 represents 25 frames a second.
        int totFrames = (int)(totalMilliseconds / 40.00);
        framePixels = new uint[mediaPlayer.NaturalVideoWidth * mediaPlayer.NaturalVideoHeight];
        previousFramePixels = new uint[framePixels.Length];
        for (int i = 0; i < totFrames; i++) {
            totalFrames.Add(TimeSpan.FromMilliseconds((((2 * i) + 1) * totalMilliseconds) / (2 * totFrames)));
            IsOpen = true;
        }        
    }
        
--------------------------
        player = new Player();
        //The program wait the player to open before continuing
        //you'll need to add the async keyword on the signature method containing this code.
        await player.Open("C:\\FileName.avi");
        
        Bitmap b = player.GetNextFrame();
