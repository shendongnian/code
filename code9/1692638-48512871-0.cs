	public void SaveImage(string filepath)
	{
		var imageData = System.IO.File.ReadAllBytes(filepath);
		var dir = Android.OS.Environment.GetExternalStoragePublicDirectory(
		Android.OS.Environment.DirectoryDcim);
		var pictures = dir.AbsolutePath;
		var filename = System.DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".jpg";
		var newFilepath = System.IO.Path.Combine(pictures, filename);
		System.IO.File.WriteAllBytes(newFilepath, imageData);
		//mediascan adds the saved image into the gallery
		var mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);
		mediaScanIntent.SetData(Android.Net.Uri.FromFile(new Java.IO.File(newFilepath)));
		Xamarin.Forms.Forms.Context.SendBroadcast(mediaScanIntent);
	}
	
