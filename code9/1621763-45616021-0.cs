    public void StartPlayer()
    {
        try
        {
            var player = new MediaPlayer();
    		var descriptor = _context.Assets.OpenFd("Test.mp3");
               
            player.SetDataSource(descriptor.FileDescriptor, descriptor.StartOffset, descriptor.Length);
            descriptor.Close();
    
            player.Prepare();
            player.Start();
        }
        catch ()
        {
        }
    }     
