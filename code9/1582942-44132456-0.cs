    EventImageFile = await CrossMedia.Current.TakePhotoAsync(
                            new StoreCameraMediaOptions
                            {
                                SaveToAlbum = true,
                                Directory = "your directory name",
                                Name = DateTime.Now + ".jpg",
                                DefaultCamera = CameraDevice.Rear,
                                //CompressionQuality = 10
                            });
        
