    public void StartPlayer(String filePath)
        {
            
         string Mp3Path = Path.Combine("/sdcard/"+
     Android.OS.Environment.DirectoryMusic,
        filePath);
            if (player == null)
            {
                player = new MediaPlayer();
            }
            
                player.Reset();
                player.SetDataSource(Mp3Path);
                player.Prepare();
                player.Start();
            
        }
