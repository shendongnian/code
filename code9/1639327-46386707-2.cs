        private async Task DetectAsync()
        {
            IList<DetectedFace> faces = null;
            // Create a VideoFrame object specifying the pixel format we want our capture image to be (NV12 bitmap in this case).
            // GetPreviewFrame will convert the native webcam frame into this format.
            const BitmapPixelFormat InputPixelFormat = BitmapPixelFormat.Nv12;
            using (VideoFrame destinationPreviewFrame = new VideoFrame(InputPixelFormat, 640, 480))
            {
                await this._mediaCapture.GetPreviewFrameAsync(destinationPreviewFrame);
                if (FaceDetector.IsBitmapPixelFormatSupported(InputPixelFormat))
                {
                    faces = await this.faceDetector.DetectFacesAsync(destinationPreviewFrame.SoftwareBitmap);
                    foreach(var face in faces)
                    {
                        // convert NV12 to RGBA16 format
                        SoftwareBitmap convertedBitmap = SoftwareBitmap.Convert(destinationPreviewFrame.SoftwareBitmap, BitmapPixelFormat.Rgba16);
                        // save the cropped image of the detected face to a file
                        StorageFile output = await _captureFolder.CreateFileAsync("photo.bmp", CreationCollisionOption.GenerateUniqueName);
                        await SaveSoftwareBitmapToFile(convertedBitmap, output, face.FaceBox);
                        // read the bitmap and send it to the face client
                        var randomAccessStream = await output.OpenReadAsync();
                        using (Stream stream = randomAccessStream.AsStreamForRead())
                        {
                            var faceAttributesToReturn = new List<FaceAttributeType>()
                        {
                            FaceAttributeType.Age,
                            FaceAttributeType.Emotion,
                            FaceAttributeType.Hair
                        };
                            Face[] detectedFaces = await this.faceClient.DetectAsync(stream, true, true, faceAttributesToReturn);
                            Debug.WriteLine(detectedFaces[0].FaceAttributes.ToString());
                        }
                    }
                }
            }
        }
        private async Task SaveSoftwareBitmapToFile(SoftwareBitmap softwareBitmap, StorageFile outputFile, BitmapBounds boundsOfFace)
        {
            using (IRandomAccessStream stream = await outputFile.OpenAsync(FileAccessMode.ReadWrite))
            {
                // Create an encoder with the desired format
                BitmapEncoder encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.BmpEncoderId, stream);
                // Set the software bitmap
                encoder.SetSoftwareBitmap(softwareBitmap);
                // Crop the image
                encoder.BitmapTransform.Bounds = boundsOfFace;
                await encoder.FlushAsync();
            }
        }
