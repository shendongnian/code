    var applicationId = "Application Id";
                    var secretKey = "secretkey";
                    var tenantId = "tenant id";
                    var adlsAccountName = "Account name";
                    var creds = ApplicationTokenProvider.LoginSilentAsync(tenantId, applicationId, secretKey).Result;
                    var adlsFileSystemClient = new DataLakeStoreFileSystemManagementClient(creds,clientTimeoutInMinutes:60);
                    var srcPath = "/mytempdir/ForDemoCode.zip";
                    var destPath = @"c:\tom\ForDemoCode1.zip";
    
                    Stopwatch stopWatch = new Stopwatch();
                    stopWatch.Start();
                    using (var stream = adlsFileSystemClient.FileSystem.Open(adlsAccountName, srcPath))
                    using (var fileStream = new FileStream(destPath, FileMode.Create))
                    {
                        stream.CopyTo(fileStream);
                    }
                    var file = new FileInfo(destPath);
                    Console.WriteLine($"File size :{file.Length}");
                    stopWatch.Stop();
                    // Get the elapsed time as a TimeSpan value.
                    TimeSpan ts = stopWatch.Elapsed;
                    // Format and display the TimeSpan value.
                    string elapsedTime = $"{ts.Hours:00}:{ts.Minutes:00}:{ts.Seconds:00}.{ts.Milliseconds/10:00}";
                    Console.WriteLine("RunTime " + elapsedTime);
                    Console.ReadKey();
