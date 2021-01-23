     DirectoryTransferContext context = new DirectoryTransferContext();
                context.FileTransferred += FileTransferredCallback;
                context.FileFailed +=FileFailedCallback;
                context.FileSkipped += FileSkippedCallback;
    
                context.SetAttributesCallback = (destination) =>
                {
                    CloudBlob destBlob = destination as CloudBlob;
                    destBlob.Properties.ContentType = "image/png";
                };
    
                context.ShouldTransferCallback = (source, destination) =>
                {
                    // Can add more logic here to evaluate whether really need to transfer the target.
                    return true;
                };
    
                // Start the upload
                var trasferStatus = await TransferManager.UploadDirectoryAsync(sourceDirPath, destDir, options, context);
    
    private static void FileTransferredCallback(object sender, TransferEventArgs e)
        {
            Console.WriteLine("Transfer Succeeds. {0} -> {1}.", e.Source, e.Destination);
        }
    
        private static void FileFailedCallback(object sender, TransferEventArgs e)
        {
            Console.WriteLine("Transfer fails. {0} -> {1}. Error message:{2}", e.Source, e.Destination, e.Exception.Message);
        }
    
        private static void FileSkippedCallback(object sender, TransferEventArgs e)
        {
            Console.WriteLine("Transfer skips. {0} -> {1}.", e.Source, e.Destination);
        }
