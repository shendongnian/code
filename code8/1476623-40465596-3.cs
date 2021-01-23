	var pdfAssetName = "PlayScriptLanguageSpecification.pdf";
    var savePath = Path.GetTempFileName();
	using (var assetStream = Application.Context.Assets.Open(pdfAssetName))
	using (var fileStream = new FileStream(savePath, FileMode.Create, FileAccess.Write))
	{
		byte[] buffer = new byte[1024];
		int readCount = 0;
		do
		{
			readCount = assetStream.Read(buffer, 0, buffer.Length);
			fileStream.Write(buffer, 0, readCount);
		} while (readCount > 0);
	}
	var targetIntent = new Intent(Intent.ActionView);
	var file = new Java.IO.File(savePath);
	var uri = FileProvider.GetUriForFile(this, PackageName, file);
	targetIntent.SetDataAndType(uri, "application/pdf");
	targetIntent.SetFlags(ActivityFlags.NoHistory);
	targetIntent.SetFlags(ActivityFlags.GrantReadUriPermission);
	Intent intent = Intent.CreateChooser(targetIntent, "Open File");
	StartActivity(intent);
