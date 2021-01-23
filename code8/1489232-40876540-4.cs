    (Element as CameraPage).TakePicture = async () =>
    {
        var data = await CapturePhoto();
        UIImage imageInfo = new UIImage(data);
        (Element as FullCameraPage.CameraPage).SetPhotoResult(data.ToArray(),
			(int)imageInfo.Size.Width,
			(int)imageInfo.Size.Height);
    };
