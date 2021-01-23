    using (var readStream = await file.OpenReadAsync())
                    {
                        var buffer = new byte[3000000].AsBuffer();
                        //var resultingBuffer = new byte[10000000];
                        Debug.Write("-------");
                        //while (true)
                        //{
                            IBuffer readBuffer = await readStream.ReadAsync(buffer, 3000000, InputStreamOptions.Partial);
    
                        //if (readBuffer.Length == 0) break;
    
                        //resultingBuffer = resultingBuffer.Concat(readBuffer.ToArray()).ToArray();
                        //}
    
                        // await stream.WriteAsync(resultingBuffer.AsBuffer());
                        var  resultingBuffer = new byte[readBuffer.Length];
                        readBuffer.CopyTo(resultingBuffer);
    
                        await stream.WriteAsync(resultingBuffer.AsBuffer());
                    }
    
                    Debug.Write("-------");
                    await stream.FlushAsync();
