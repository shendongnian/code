	class Program
		{
			static void Main(string[] args)
			{
				IList<string> waitForAllTheseFilesToBeCopied = new List<string>();
				waitForAllTheseFilesToBeCopied.Add("File1.txt");
				waitForAllTheseFilesToBeCopied.Add("File2.txt");
				waitForAllTheseFilesToBeCopied.Add("File3.txt");
				string watchPath = @"C:\OutputFolder\";
				CustomFileWatcher customWatcher = new CustomFileWatcher(waitForAllTheseFilesToBeCopied, watchPath);
				customWatcher.FilesCreated += customWatcher_FilesCreated;
			}
			static void customWatcher_FilesCreated(object sender, EventArgs e)
			{
				// All files created.
			}
		}
