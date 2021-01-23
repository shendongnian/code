    private void LifeChattingManagerForm_Load(object sender, EventArgs e)
            {
                if (!AudioCapture.Initalized)
                {
                    AudioCapture.Initalize();
                    AudioCapture.StartCapturing();
                }
          
                AudioCapture.DataAvailable += AudioEvent;
                AudioPlayer.DisposeInput = false;
                AudioPlayer.Run();
            }
    
            private void AudioEvent(byte[] buffer)
            {
                if (!Calling) return;
                var audioPackage = new SAudioPackage(buffer);
                HandleClient.Send(audioPackage);
            }
