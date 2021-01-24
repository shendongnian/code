    PrivateKeyFile ObjPrivateKey = new PrivateKeyFile(keyStream);
    PrivateKeyAuthenticationMethod ObjPrivateKeyAutentication =
        new PrivateKeyAuthenticationMethod(username, ObjPrivateKey);
    var connectionInfo =
        new ConnectionInfo(hostAddress, port, username, ObjPrivateKeyAutentication);
    bool retry = false;
    do
    {
        bool retrying = retry;
        retry = false;
        using (var client = new SftpClient(connectionInfo))
        {
            client.Connect();
            if (!client.Exists(source))
            {
                return false;
            }
            var fileName = Path.GetFileName(source);
            var destinationFile = Path.Combine(destination, fileName);
            try
            {
                Stream destinationStream;
                if (retrying)
                {
                    destinationStream = new FileStream(destinationFile, FileMode.Append);
                }
                else
                {
                    destinationStream = new FileStream(destinationFile, FileMode.Create);
                }
                using (destinationStream)
                using (var sourceStream = client.Open(source, FileMode.Open))
                {
                    sourceStream.Seek(destinationStream.Length, SeekOrigin.Begin);
                    // You can simply use sourceStream.CopyTo(destinationStream) here.
                    // But if you need to monitor download progress, you have to loop yourself.
                    byte[] buffer = new byte[81920];
                    int read;
                    ulong total = (ulong)destinationStream.Length;
                    while ((read = sourceStream.Read(buffer, 0, buffer.Length)) != 0)
                    {
                        destinationStream.Write(buffer, 0, read);
                        total = total + (ulong)read;
                        // report progress
                        printActionDel(total);
                    }
                }
            }
            catch (SshException e)
            {
                retry = true;
            }
        }
    }
    while (retry);
