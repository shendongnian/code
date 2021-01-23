        // Set the capture element's source to show it in the UI
            captureElement.Source = mediaCapture;
            // Start the preview
            await mediaCapture.StartPreviewAsync();
    ......
        SoftwareBitmapLuminanceSource luminanceSource = null;
                try
                {
                    // Get preview 
                    var frame = await mediaCapture.GetPreviewFrameAsync(videoFrame);
                    // Create our luminance source
                    luminanceSource = new SoftwareBitmapLuminanceSource(frame.SoftwareBitmap);
    ......
         ZXing.Result result = null;
                try
                {
                    // Try decoding the image
                    if (luminanceSource != null)
                        result = zxing.Decode(luminanceSource);
