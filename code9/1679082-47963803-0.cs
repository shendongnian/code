    public class KeyValue: ITaskItem
	{
		string _spec = String.Empty;
		
		public KeyValue(string key, string value)
		{
			_spec = key;
			metadata.Add("value", value);
		}
		
		Dictionary<string,string> metadata = new Dictionary<string,string>();
		
		public string ItemSpec
		{
			get {return _spec;}
			set {}
		}
		public ICollection MetadataNames
		{
			get {return metadata.Keys;}
		}
		public int MetadataCount
		{
			get {return metadata.Keys.Count;}
		}
		public string GetMetadata(string metadataName)
		{
			return metadata[metadataName];
		}
		public void SetMetadata(string metadataName, string metadataValue) 
		{
			metadata[metadataName] = metadataValue;
		}
		public void RemoveMetadata(string metadataName)
		{
		}
		public void CopyMetadataTo(ITaskItem destinationItem)
		{
		}
		public IDictionary CloneCustomMetadata()
		{
			  return metadata;
		}
	}
