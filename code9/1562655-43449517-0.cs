    _mediaCapture = new MediaCapture();
    var allVideoDevices = await DeviceInformation.FindAllAsync(DeviceClass.VideoCapture);
    var desiredDevice = allVideoDevices.FirstOrDefault(x => x.EnclosureLocation != null && x.EnclosureLocation.Panel == Windows.Devices.Enumeration.Panel.Back);
    _cameraDevice = desiredDevice ?? allVideoDevices.FirstOrDefault();
    _rotationHelper = new CameraRotationHelper(_cameraDevice.EnclosureLocation);
    _mediaCapture.Failed += MediaCapture_Failed;
    var settings = new MediaCaptureInitializationSettings { VideoDeviceId = _cameraDevice.Id };
    await _mediaCapture.InitializeAsync(settings);
    //Add the preview code snippet
    PreviewControl.Source = _mediaCapture;
    await _mediaCapture.StartPreviewAsync(); 
    var encodingProfile = MediaEncodingProfile.CreateMp4(VideoEncodingQuality.Auto);
    var rotationAngle = CameraRotationHelper.ConvertSimpleOrientationToClockwiseDegrees(_rotationHelper.GetCameraCaptureOrientation());
    Guid RotationKey = new Guid("C380465D-2271-428C-9B83-ECEA3B4A85C1");
    encodingProfile.Video.Properties.Add(RotationKey, PropertyValue.CreateInt32(rotationAngle));
    var videoEncodingProperties = _mediaCapture.VideoDeviceController.GetMediaStreamProperties(MediaStreamType.VideoPreview);
    MediaPropertySet mediaPropertySet = new MediaPropertySet();
    await _mediaCapture.SetEncodingPropertiesAsync(MediaStreamType.VideoPreview, videoEncodingProperties, mediaPropertySet);
