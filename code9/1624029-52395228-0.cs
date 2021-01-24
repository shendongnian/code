	public static class HttpContentExtensions
	{
		public static Task ReadAsFileAsync(this HttpContent content, string filename, bool overwrite)
		{
			string pathname = Path.GetFullPath(filename);
			if (!overwrite && File.Exists(filename))
			{
				throw new InvalidOperationException(string.Format("File {0} already exists.", pathname));
			}
	
			FileStream fileStream = null;
			try
			{
				fileStream = new FileStream(pathname, FileMode.Create, FileAccess.Write, FileShare.None);
				return content.CopyToAsync(fileStream).ContinueWith(
					(copyTask) =>
					{
						fileStream.Close();
					});
			}
			catch
			{
				if (fileStream != null)
				{
					fileStream.Close();
				}
	
				throw;
			}
		}
	}
