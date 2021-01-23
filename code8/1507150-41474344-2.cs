     if (player == null)
     {
          player = new MediaPlayer();
     }
     AssetFileDescriptor afd = Assets.OpenFd("filenameinAssetsfolder.mp3");
     player.Reset();
     player.SetDataSource(afd.FileDescriptor);
     player.Prepare();
     player.Start();
