    /// <summary>
    /// Creates the Blob service client.
    /// </summary>
    /// <returns>A <see cref="CloudBlobClient"/> object.</returns>
    
    public CloudBlobClient CreateCloudBlobClient()
    {
        if (this.BlobEndpoint == null)
    
        {
    
            throw new InvalidOperationException(SR.BlobEndPointNotConfigured);
    
        }
        return new CloudBlobClient(this.BlobStorageUri, this.Credentials);
    }
