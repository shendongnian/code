    private async Task DetectAsync()
    {
        IList<DetectedFace> faces = null;
        const BitmapPixelFormat InputPixelFormat = BitmapPixelFormat.Nv12;
        using (VideoFrame destinationPreviewFrame = new VideoFrame(InputPixelFormat, 640, 480))
        {
            await this._mediaCapture.GetPreviewFrameAsync(destinationPreviewFrame);
    
            if (FaceDetector.IsBitmapPixelFormatSupported(InputPixelFormat))
            {
                faces = await this.faceDetector.DetectFacesAsync(destinationPreviewFrame.SoftwareBitmap);
    
                foreach (var face in faces)
                {
                    // convert NV12 to RGBA16 format
                    SoftwareBitmap convertedBitmap = SoftwareBitmap.Convert(destinationPreviewFrame.SoftwareBitmap, BitmapPixelFormat.Rgba16);
    
                    // get the raw bytes of the detected face
                    byte[] rawBytes = await GetBytesFromBitmap(convertedBitmap, BitmapEncoder.BmpEncoderId, face.FaceBox);
    
                    // read the bitmap and send it to the face client
                    using (Stream stream = rawBytes.AsBuffer().AsStream())
                    {
                        var faceAttributesToReturn = new List<FaceAttributeType>()
                        {
                            FaceAttributeType.Age,
                            FaceAttributeType.Emotion,
                            FaceAttributeType.Hair
                        };
    
                        Face[] detectedFaces = await this.faceClient.DetectAsync(stream, true, true, faceAttributesToReturn);
    
                        Debug.Assert(detectedFaces.Length > 0);
                    }
                }
            }
        }
    }
    
    private async Task<byte[]> GetBytesFromBitmap(SoftwareBitmap soft, Guid encoderId, BitmapBounds bounds)
    {
        byte[] array = null;
    
        using (var ms = new InMemoryRandomAccessStream())
        {
            BitmapEncoder encoder = await BitmapEncoder.CreateAsync(encoderId, ms);
            encoder.SetSoftwareBitmap(soft);
    
            // apply the bounds of the face
            encoder.BitmapTransform.Bounds = bounds;
    
            await encoder.FlushAsync();
    
            array = new byte[ms.Size];
    
            await ms.ReadAsync(array.AsBuffer(), (uint)ms.Size, InputStreamOptions.None);
        }
    
        return array;
    }
