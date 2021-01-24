    public static class ImageConverter
	{
		public static async Task<byte[]> ReadFully(Stream input)
		{
			byte[] buffer = new byte[16 * 1024];
			using (var ms = new MemoryStream())
			{
				int read;
				while ((read = await input.ReadAsync(buffer, 0, buffer.Length)) > 0)
				{
					ms.Write(buffer, 0, read);
				}
				return ms.ToArray();
			}
		}
	}
