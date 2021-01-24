    async private void InitMediaCapture()
    {
        _mediaCapture = new MediaCapture();
        var cameraDevice = await FindCameraDeviceByPanelAsync(Windows.Devices.Enumeration.Panel.Back);
        var settings = new MediaCaptureInitializationSettings { VideoDeviceId = cameraDevice.Id };
        await _mediaCapture.InitializeAsync(settings);
        _displayRequest.RequestActive();
        PreviewControl.Source = _mediaCapture;
        await _mediaCapture.StartPreviewAsync();
        
        var picturesLibrary = await StorageLibrary.GetLibraryAsync(KnownLibraryId.Pictures);
        _captureFolder = picturesLibrary.SaveFolder ?? ApplicationData.Current.LocalFolder;
    
        await Task.Delay(500);
        CaptureImage();
    }
     async private void CaptureImage()
     {
         var storeFile = await _captureFolder.CreateFileAsync("PreviewFrame.jpg", CreationCollisionOption.GenerateUniqueName);
         ImageEncodingProperties imgFormat = ImageEncodingProperties.CreateJpeg();
         await _mediaCapture.CapturePhotoToStorageFileAsync(imgFormat, storeFile);
         await _mediaCapture.StopPreviewAsync();
     }
     private static async Task<DeviceInformation> FindCameraDeviceByPanelAsync(Windows.Devices.Enumeration.Panel desiredPanel)
     {
         // Get available devices for capturing pictures
         var allVideoDevices = await DeviceInformation.FindAllAsync(DeviceClass.VideoCapture);
    
         // Get the desired camera by panel
         DeviceInformation desiredDevice = allVideoDevices.FirstOrDefault(x => x.EnclosureLocation != null && x.EnclosureLocation.Panel == desiredPanel);
    
         // If there is no device mounted on the desired panel, return the first device found
         return desiredDevice ?? allVideoDevices.FirstOrDefault();
     }
