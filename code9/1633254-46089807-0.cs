    #if !PCL
            /// <summary>
            /// Uploads a stream to a block blob in a storage account associated with the IoTHub for that device.
            /// If the blob already exists, it will be overwritten.
            /// </summary>
            /// <param name="blobName"></param>
            /// <param name="source"></param>
            /// <returns>AsncTask</returns>
            public Task UploadToBlobAsync(String blobName, System.IO.Stream source)
            {
                if (String.IsNullOrEmpty(blobName))
                {
                    throw Fx.Exception.ArgumentNull("blobName");
                }
                if (source == null)
                {
                    throw Fx.Exception.ArgumentNull("source");
                }
                if (blobName.Length > 1024)
                {
                    throw Fx.Exception.Argument("blobName", "Length cannot exceed 1024 characters");
                }
                if (blobName.Split('/').Count() > 254)
                {
                    throw Fx.Exception.Argument("blobName", "Path segment count cannot exceed 254");
                }
                HttpTransportHandler httpTransport = null;
    #if !WINDOWS_UWP
                //We need to add the certificate to the fileUpload httpTransport if DeviceAuthenticationWithX509Certificate
                if (this.Certificate != null)
                {
                    Http1TransportSettings transportSettings = new Http1TransportSettings();
                    transportSettings.ClientCertificate = this.Certificate;
                    httpTransport = new HttpTransportHandler(null, iotHubConnectionString, transportSettings);
                }
                else
                {
                    httpTransport = new HttpTransportHandler(iotHubConnectionString);
                }
    #else 
                httpTransport = new HttpTransportHandler(iotHubConnectionString);
    #endif
                return httpTransport.UploadToBlobAsync(blobName, source);
            }
    #endif
