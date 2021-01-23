            var reader = PipeReader.Create(serial.BaseStream);
            while (!token.IsCancellationRequested)
            {
                ReadResult result = await reader.ReadAsync(token);
                    
                // find and handle packets
                // Normally wrapped in a handle-method and a while to allow processing of several packets at once 
                // while(HandleIncoming(result))
                // {
                        result.Buffer.Slice(10); // Moves Buffer.Start to position 10, which we use later to advance the reader
                // }
                // Tell the PipeReader how much of the buffer we have consumed. This will "free" that part of the buffer
                reader.AdvanceTo(result.Buffer.Start, result.Buffer.End);
                // Stop reading if there's no more data coming
                if (result.IsCompleted)
                {
                    break;
                }
            }
