    private async Task DoMyWork()
    {
		var z = Task.Factory.StartNew(
		() =>
		{
			cr.Create(current_file_name, output);
			File.Copy(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\HTMLViewer.html", outputPath + "\\HTMLViewer.html", true);
	
			ZipFile.CreateFromDirectory(outputPath, Directory.GetParent(outputPath) + "\\" + Path.GetFileNameWithoutExtension(current_file_name) + ".zip");
		});
	
		var tasks = new[] { z };
		await Task.WhenAll(tasks);
		
		_window.MainDispatcher.BeginInvoke(() =>
		{
			_popUp.PopUpText = "DeepZoom completed";
			_popUp.BeginPopUpTimer();
		});
	}
