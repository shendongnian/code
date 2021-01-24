    private async Task MessageLoop(NetworkStream networkStream)
    {
        //Lets pretend our protocall sends a byte with:
        // - 1 if the next object will be a Foo,
        // - 2 if the next object will be a Bar
        // - 3 if the next object will be a Int32.
        var formatter = new BinaryFormatter();
        byte[] buffer = new byte[1024];
        while (true)
        {
            var read = await networkStream.ReadAsync(buffer, 0, 1).ConfigureAwait(false);
            if (read < 0)
            {
                await LogStreamDisconnectAsync();
            }
            
            switch (buffer[0])
            {
                case 1:
                    //If we are on a SynchronizationContext run the deseralize function on a new thread because that call will block.
                    Func<Foo> desearalize = ()=> (Foo)formatter.Deserialize(networkStream);
                    Foo foo;
                    if (SynchronizationContext.Current != null)
                    {
                        foo = await Task.Run(desearalize).ConfigureAwait(false);
                    }
                    else
                    {
                        foo = desearalize();
                    }
                    await ProcessFooAsync(foo).ConfigureAwait(false);
                    break;
                case 2:
                    var bar = await Task.Run(() => (Bar)formatter.Deserialize(networkStream)).ConfigureAwait(false);
                    await ProcessBarAsync(bar).ConfigureAwait(false);
                    break;
                case 3:
                    //We have to loop on Read because we may not get 4 bytes back when we do the call, so we keep calling till we fill our buffer.
                    var bytesRead = 0;
                    while (bytesRead < 4)
                    {
                        //We don't want to overwrite the buffer[0] so we can see the value in the debugger if we want, so we do 1 + bytesRead as the offset.
                        bytesRead += await networkStream.ReadAsync(buffer, 1 + bytesRead, 4 - bytesRead).ConfigureAwait(false);
                    }
                    //This assumes both ends have the same value for BitConverter.IsLittleEndian
                    int num = BitConverter.ToInt32(buffer, 1);
                    await DoSomethingWithANumberAsync(num).ConfigureAwait(false);
                    
                    return;
                default:
                    await LogInvaidRequestTypeAsync(buffer[0]).ConfigureAwait(false);
                    return;
            }
        }
    }
