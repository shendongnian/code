        const BitmapPixelFormat InputPixelFormat = BitmapPixelFormat.Nv12;
        using (VideoFrame destinationPreviewFrame = new VideoFrame(InputPixelFormat, 640, 480))
        {
            await this._mediaCapture.GetPreviewFrameAsync(destinationPreviewFrame);
            if (FaceDetector.IsBitmapPixelFormatSupported(InputPixelFormat))
            {
                faces = await this.faceDetector.DetectFacesAsync(destinationPreviewFrame.SoftwareBitmap);
                // convert NV12 to RGBA16 format
                SoftwareBitmap convertedBitmap = SoftwareBitmap.Convert(destinationPreviewFrame.SoftwareBitmap, BitmapPixelFormat.Rgba16);
                // save the bitmap to a file
                StorageFile output = await _captureFolder.CreateFileAsync("photo.bmp", CreationCollisionOption.GenerateUniqueName);
                await SaveSoftwareBitmapToFile(convertedBitmap, output);
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
