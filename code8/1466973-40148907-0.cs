	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
	using System.Text;
	namespace CustomFileWatcher
	{
		public class CustomFileWatcher : IDisposable
		{
			private FileSystemWatcher fileWatcher;
			private IList<string> fileList;
			private IList<string> createdFiles;
			public event EventHandler FilesCreated;
			protected void OnFilesCreated(EventArgs e)
			{
				var handler = FilesCreated;
				if (handler != null)
					handler(this, e);
			}
			public CustomFileWatcher(IList<string> waitForTheseFiles, string path)
			{
				fileList = waitForTheseFiles;
				createdFiles = new List<string>();
				fileWatcher = new FileSystemWatcher(path);
				fileWatcher.Created += fileWatcher_Created;
			}
			void fileWatcher_Created(object sender, FileSystemEventArgs e)
			{
				foreach (var item in fileList)
				{
					if (fileList.Contains(e.Name))
					{
						if (!createdFiles.Contains(e.Name))
						{
							createdFiles.Add(e.Name);
						}
					}
				}
				if (createdFiles.SequenceEqual(fileList))
					OnFilesCreated(new EventArgs());
			}
			public CustomFileWatcher(IList<string> waitForTheseFiles, string path, string filter)
			{
				fileList = waitForTheseFiles;
				fileWatcher = new FileSystemWatcher(path,filter);
			}
			public void Dispose()
			{
				if (fileWatcher != null)
					fileWatcher.Dispose();
			}
		}
	}
