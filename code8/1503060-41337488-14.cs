	public class DownloadedImageModel
	{
		[PrimaryKey]
		public string ImageUrl { get; set;}
		public byte[] DownloadedImageBlob { get; set; }
		public ImageSource DownloadedImageAsImageStreamFromBase64String
		{
			get
			{
				try
				{
					if (DownloadedImageBlob == null)
						return null;
					var imageByteArray = DownloadedImageBlob;
					return ImageSource.FromStream(() => new MemoryStream(imageByteArray));
				}
				catch (Exception e)
				{
					Debug.WriteLine(e);
					return null;
				}
			}
		}
	}
