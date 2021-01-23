    public static class InkCanvasExtensions
	{
		public static async Task RestoreStrokesAsync(this InkCanvas inkCanvas, StorageFolder folder, string fileName)
		{
			try
			{
				var file = folder.GetFileAsync(fileName);
				using (var stream = await file.OpenAsync(FileAccessMode.Read))
				{
					using (var inputStream = stream.GetInputStreamAt(0))
					{
						await inkCanvas.InkPresenter.StrokeContainer.LoadAsync(inputStream);
					}
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
			}
		}
	
		public static async Task<bool> StoreStrokesAsync(this InkCanvas inkCanvas, StorageFolder folder, string fileName)
		{
			try
			{
				var file = await folder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
				CachedFileManager.DeferUpdates(file);
				using (var stream = await file.OpenAsync(FileAccessMode.ReadWrite))
				{
					using (var outputStream = stream.GetOutputStreamAt(0))
					{
						await inkCanvas.InkPresenter.StrokeContainer.SaveAsync(outputStream);
						await outputStream.FlushAsync();
					}
				}
				var status = await CachedFileManager.CompleteUpdatesAsync(file);
				return status == FileUpdateStatus.Complete;
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
			}
			return false;
		}
	}
