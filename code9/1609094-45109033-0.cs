    while (FrameDecoderActive)
    {
        StopFrameDecoding.Token.ThrowIfCancellationRequested();
        
        // some other stuff
        while (FrameDecoderActive)
        {
            // more stuff
            // never checks for cancellation!
        }
    }
