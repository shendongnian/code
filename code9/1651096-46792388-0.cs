    private void UpdateImageFromBuffer(byte[] yourBuffer)
    {
        ThreadPool.QueueUserWorkItem(delegate {
            try {
                
                SelectedImageLoaded = false; // Set the notification Property and notify that image is being loaded.
                
                using (MemoryStream memoryStream = new MemoryStream(yourBuffer)) // Remember to provide the yourBuffer variable.
                {
                    var imageSource = new BitmapImage();
                    imageSource.BeginInit();
                    imageSource.StreamSource = memoryStream;
                    imageSource.EndInit();
                    ImageSelected = imageSource; // Assign ImageSource to your ImageSelected Property.
                }
    
            } catch (Exception ex) {
                /* You might want to catch this */
            } finally {
                SelectedImageLoaded = true; // Notify that image has been loaded
            }
        });
    }
