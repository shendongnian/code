    private async Task<string> Capture(StorageFile file, TimeSpan timeOfFrame, Size imageDimension)
    {
	    if (file == null)
	{
		return null;
	}
	//Get FrameWidth & FrameHeight
	List<string> encodingPropertiesToRetrieve = new List<string>();
	encodingPropertiesToRetrieve.Add("System.Video.FrameHeight");
	encodingPropertiesToRetrieve.Add("System.Video.FrameWidth");
	IDictionary<string, object> encodingProperties = await file.Properties.RetrievePropertiesAsync(encodingPropertiesToRetrieve);
	uint frameHeight = (uint)encodingProperties["System.Video.FrameHeight"];
	uint frameWidth = (uint)encodingProperties["System.Video.FrameWidth"];
	//Get image stream
	var clip = await MediaClip.CreateFromFileAsync(file);
	var composition = new MediaComposition();
	composition.Clips.Add(clip);
	var imageStream = await composition.GetThumbnailAsync(timeOfFrame, (int)frameWidth, (int)frameHeight, VideoFramePrecision.NearestFrame);
	//Create BMP
	var writableBitmap = new WriteableBitmap((int)frameWidth, (int)frameHeight);
	writableBitmap.SetSource(imageStream);
	//Get stream from BMP
	string mediaCaptureFileName = "IMG" + Guid.NewGuid().ToString().Substring(0, 4) + ".jpg";
	var saveAsTarget = await CreateMediaFile(mediaCaptureFileName);
	Stream stream = writableBitmap.PixelBuffer.AsStream();
	byte[] pixels = new byte[(uint)stream.Length];
	await stream.ReadAsync(pixels, 0, pixels.Length);
	
	using (var writeStream = await saveAsTarget.OpenAsync(FileAccessMode.ReadWrite))
	{
		var encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.JpegEncoderId, writeStream);
		encoder.SetPixelData(
			BitmapPixelFormat.Bgra8,
			BitmapAlphaMode.Premultiplied,
			(uint)writableBitmap.PixelWidth,
			(uint)writableBitmap.PixelHeight,
			96,
			96,
			pixels);
		await encoder.FlushAsync();                
		using (var outputStream = writeStream.GetOutputStreamAt(0))
		{
			await outputStream.FlushAsync();
		}
	}
	return saveAsTarget.Name;
    }
