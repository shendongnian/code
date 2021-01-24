	using System.IO;
	class DirectoryManager
	{
		internal static void CopyDirectory(string input, string output)
		{
			DirectoryInfo dir = new DirectoryInfo(input);
			if (dir.Exists)
			{
				DirectoryInfo[] dirs = dir.GetDirectories();
				Directory.CreateDirectory(output);
				FileInfo[] files = dir.GetFiles();
				foreach (FileInfo file in files)
				{
					string temppath = Path.Combine(output, file.Name);
					file.CopyTo(temppath, false);
				}
				foreach (DirectoryInfo subdir in dirs)
				{
					string temppath = Path.Combine(output, subdir.Name);
					CopyDirectory(subdir.FullName, temppath);
				}
			}
		}
	}
