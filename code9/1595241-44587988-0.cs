	internal sealed class AppSettingsSerializer
	{
		private AppSettingsSerializer() { }
		static int BufferSize { get { return 4096; } }
		internal static AppSettings GetAppSettings(string filePath)
		{
			if(File.Exists(filePath) == false)
				return new AppSettings();
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(AppSettings));
			using(FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.None, BufferSize, FileOptions.SequentialScan))
			{
				XmlReader xmlReader = XmlReader.Create(fileStream);
				return (AppSettings)xmlSerializer.Deserialize(xmlReader);
			}
		}
		internal static void SetAppSettings(string filePath, AppSettings appSettings)
		{
			XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces();
			xmlSerializerNamespaces.Add("", "");
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(AppSettings));
			using(FileStream fileStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None, BufferSize, FileOptions.WriteThrough))
			{
				XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
				xmlWriterSettings.Indent = true;
				xmlWriterSettings.NewLineOnAttributes = true;
				XmlWriter xmlWriter = XmlWriter.Create(fileStream, xmlWriterSettings);
				xmlSerializer.Serialize(xmlWriter, appSettings, xmlSerializerNamespaces);
			}
		}
	}
	public sealed class AppSettings
	{
		public bool Setting1 { get; set; }
		public string Setting2 { get; set; }
		public AppSettings()
		{
			Setting1 = false;
			Setting2 = "localhost";
		}
	}
