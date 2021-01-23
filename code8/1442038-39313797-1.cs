    public class FolderFilesAggregate
	{
		public IEnumerable<FolderFiles> FolderFiles { get; set; }
	}
	public class FolderFiles
	{
		public string FileName { get; set; }
		public string FileType { get; set; }
	}
	class Program
	{
		static void Main(string[] args)
		{
			// get your folder files in any way you want to, I hardcoded it to simplify the example
			var folderFiles = new List<FolderFiles>
							  {
								  new FolderFiles
								  {
									  FileName = @"C:\\Users\\Joko\\Documents\\Visual Studio 2015\\Projects\\Research\\GetFilesFromFolder\\GetFilesFromFolder\\bin\\Debug\\GetFilesFromFolder.exe",
									  FileType = ".exe"
								  },
								  new FolderFiles
								  {
									  FileName = @"C:\\Users\\Joko\\Documents\\Visual Studio 2015\\Projects\\Research\\GetFilesFromFolder\\GetFilesFromFolder\\bin\\Debug\\GetFilesFromFolder.vshost.exe",
									  FileType = ".exe"
								  }
							  };
			var folderFilesAggregate = new FolderFilesAggregate
									   {
										   FolderFiles = folderFiles
									   };
			// serialize your aggregate object
			var serializedFolderFilesAggregate = Newtonsoft.Json.JsonConvert.SerializeObject(folderFilesAggregate, Formatting.Indented);
			// write it to a file
			System.IO.File.WriteAllText(@"C:\output.json", serializedFolderFilesAggregate);
		}
	}
