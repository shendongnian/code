    // Create a new class instance.
    Sftp client = new Sftp();
    // Connect to the SFTP server.
    client.Connect("localhost");
    // Authenticate.
    client.Authenticate("test", "test");
    // ... 
    // Upload local file 'c:\test.dat' to '/test.dat'.
    client.UploadFile(@"xxx\temp.csv", "/temp.new.csv");
    // ... 
    // Disconnect.
    client.Disconnect();
