    while (s.DataAvailable)
    {
        // try to read a chunk of data from the inbound stream
        int bytesRead = s.Read(someBuffer, 0, someBuffer.Length);
        if(bytesRead > 0) {
             // append to our per-socket back-buffer
             perSocketStream.Position = perSocketStream.Length;
             perSocketStream.Write(someBuffer, 0, bytesRead);
             int frameSize; // detect any complete frame(s)
             while((frameSize = DetectFirstCRLF(perSocketStream)) >= 0) {
                  // decode it as text
                  var backBuffer = perSocketStream.GetBuffer(); 
                  string message = encoding.GetString(
                        backBuffer, 0, frameSize);
                  // remove the frame from the start by copying down and resizing
                  Buffer.BlockCopy(backBuffer, frameSize, backBuffer, 0,
                      (int)(backBuffer.Length - frameSize));
                  perSocketStream.SetLength(backBuffer.Length - frameSize);
                  // process it
                  ProcessMessage(message);
             }
        }
    }
