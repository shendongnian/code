	[System.Serializable]
	public class SaveManager
	{
		public SaveManager()
		{
			Version = 1.5f;
		}
		[OptionalField]
		public float Version { get; set; }
	}
