	[Serializable]
	public class ImageModel
	{
		public string Text { get; set; }
		public Uri Uri { get; set; }
	}
	public class ImageCollectionModel
	{
		public List<ImageModel> Collection { get; } = new List<ImageModel>();
		private BinaryFormatter Formatter = new BinaryFormatter();
		public bool Save(FileInfo file)
		{
			try
			{
				using (var stream = file.OpenWrite())
				{
					Formatter.Serialize(stream, Collection);
					return true;
				}
			}
			catch (Exception)
			{
				return false;
			}
		}
		public bool Load(FileInfo file)
		{
			try
			{
				using (var stream = file.OpenRead())
				{
					var col = Formatter.Deserialize(stream) as List<ImageModel>;
					Collection.Clear();
					Collection.AddRange(col);
					return true;
				}
			}
			catch (Exception)
			{
				return false;
			}
		}
	}
