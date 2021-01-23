    public static void MonitorCopy(CloudBlobContainer destContainer)
    {
        bool pendingCopy = true;
 
        while (pendingCopy)
        {
            pendingCopy = false;
            var destBlobList = destContainer.ListBlobs(
                true, BlobListingDetails.Copy);
            foreach (var dest in destBlobList)
            {
                var destBlob = dest as CloudBlob;
 
                if (destBlob.CopyState.Status == CopyStatus.Aborted ||
                    destBlob.CopyState.Status == CopyStatus.Failed)
                {
                    // Log the copy status description for diagnostics 
                    // and restart copy
                    Log(destBlob.CopyState);
                    pendingCopy = true;
                    destBlob.StartCopyFromBlob(destBlob.CopyState.Source);
                }
                else if (destBlob.CopyState.Status == CopyStatus.Pending)
                {
                    // We need to continue waiting for this pending copy
                    // However, let us log copy state for diagnostics
                    Log(destBlob.CopyState);
                    pendingCopy = true;
                }
                // else we completed this pending copy
            }
 
            Thread.Sleep(waitTime);
        };
    }
