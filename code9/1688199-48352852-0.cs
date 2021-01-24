	public static class XElementExtensions
	{
		public static async Task WriteToAsync(this XContainer element, Stream stream, bool defAttr = true, bool indent = false)
		{
			var settings = new XmlWriterSettings
			{
				Async = true,
				CloseOutput = false,
				Indent = indent,
			};			
			
			using (var writer = XmlWriter.Create(stream, settings))
			using (var reader = element.CreateReader())
			{
				await writer.WriteNodeAsync(reader, defAttr);
			}
		}
	}
