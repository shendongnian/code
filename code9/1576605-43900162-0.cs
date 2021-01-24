	var bitmap = BitmapFactory.BitmapFactory.DecodeStream(stream);
	var path = Path.Combine(GetExternalFilesDir(Environment.DirectoryDocuments).AbsolutePath, "sameImagePath.jpg");
	if (!File.Exists(path))
	{
		using (var filestream = new FileStream(path, FileMode.Create))
		{
			if (bitmap.Compress(Bitmap.CompressFormat.Jpeg, 50, filestream))
			{
				filestream.Flush();
			}
		}
	}
	bitmap.Recycle();
	bitmap.Dispose();
