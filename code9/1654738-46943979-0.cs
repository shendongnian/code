	private async void BeginScanButton_Click(object sender, EventArgs e)
	{
		if (_osuDirectory == null)
			MessageBox.Show("You have not chosen an Osu! directory yet.");
		else
		{
			var exts = new[]
			{
				_jpgFilesChecked ? "*.jpg" : null,
				_pngFilesChecked ? "*.png" : null,
				_wavFilesChecked ? "*.wav" : null,
				_aviFilesChecked ? "*.avi" : null,
			}.Where(x => x != null);
		
			var query =
				from ext in exts.ToObservable()
				from fs in Observable.Start(() => FileParser.ParseFiles(_osuDirectory, ext))
				from f in fs
				select f;
		
			var files = await query.ToArray();
		
			FileList.AddRange(files);
		}
	}
	
	public static class FileParser
	{
		public static string[] ParseFiles(string dir, string extension)
		{
			return Directory.GetFiles(dir, extension, SearchOption.AllDirectories);
		}
	}
