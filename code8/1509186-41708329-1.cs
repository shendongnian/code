    foreach (var fileDetail in files)
    {
        foreach (var destinationPath in fileDetail.DestinationPaths)
            Directory.CreateDirectory(Path.GetDirectoryName(destinationPath));
        // Set up progress
        FileCopyEntryProgress progress = new FileCopyEntryProgress(fileDetail);
        // Set up the source and outputs
        using (var source = new FileStream(fileDetail.SourcePath, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize, FileOptions.SequentialScan))
        using (var outputs = new CompositeDisposable(fileDetail.DestinationPaths.Select(p => new FileStream(p, FileMode.Create, FileAccess.Write, FileShare.None, bufferSize))))
        {
            // Set up the copy operation
            var buffer = new byte[bufferSize];
            int read;
            // Read the file
            while ((read = source.Read(buffer, 0, buffer.Length)) > 0)
            {
                // Copy to each drive
                await Task.WhenAll(outputs.Select(async destination => await ((FileStream)destination).WriteAsync(buffer, 0, read)));
                // Report progress
                if (onDriveCopyFile != null)
                {
                    progress.BytesCopied = read;
                    progress.TotalBytesCopied += read;
                    onDriveCopyFile.Report(progress);
                }
            }
        }
        if (ct.IsCancellationRequested)
            break;
    }
