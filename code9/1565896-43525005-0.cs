	/// <summary>
	/// Enumerates the paths in the <c>PATH</c> environment variable, looking for <paramref name="filesToFind"/>,
	/// then checks their bitness and if it's a conflicting bitness in one of the Program Files directories,
	/// looks into the other Program File directory and updates <c>PATH</c> in consequence when successful.
	/// </summary>
	/// <param name="filesToFind">[in] File names.</param>
	/// <param name="oldPath">[out] Old value of <c>PATH</c>. This parameter is always set.</param>
	/// <param name="foundPath">[out] Directory in which the files were found, or <c>null</c> if they weren't.</param>
	/// <returns><c>true</c> if the <c>PATH</c> environment variable was modified.</returns>
	public static bool FindDirInPathAndUpdatePathWithBitness(string[] filesToFind, out string oldPath, out string foundPath)
	{
		if(filesToFind==null || filesToFind.Length==0)
			throw new ArgumentException("filesToFind must be a non-empty array of file names.", "filesToFind");
		string pathEnvVariable = Environment.GetEnvironmentVariable("PATH");
		oldPath = pathEnvVariable;
		foundPath = null;
		if(!string.IsNullOrEmpty(pathEnvVariable))
		{
			string[] pathArray = pathEnvVariable.Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
			for(int iPath=0 ; iPath<pathArray.Length ; iPath++)
			{
				string pathDirectory = pathArray[iPath];
				bool allFound = true;
				foreach(string fileName in filesToFind)
				{
					string filePath = Path.Combine(pathDirectory, fileName);
					if(!File.Exists(filePath))
					{
						allFound = false;
						break;
					}
				}
				//If all files were found in this directory
				if(allFound)
				{
					//Now the fun begins
					try
					{
						string firstFilePath = Path.Combine(pathDirectory, filesToFind[0]);
						bool runningWin64 = BitnessHelper.IsWin64;
						var fileBitness = BitnessHelper.RetrieveMachine(firstFilePath);
						if(runningWin64 != (fileBitness==BitnessHelper.Machine.x64))
						{
							//Bitness conflict detected. Is this directory in %ProgramFiles%?
							bool bHandled = HandleBitnessConflict(ref pathDirectory, filesToFind[0], runningWin64, fileBitness);
							if(bHandled)
							{
								pathArray[iPath] = pathDirectory;
								string newPath = string.Join(";", pathArray);
								Environment.SetEnvironmentVariable("PATH", newPath);
								return true;
							}
							//Otherwise, several possible scenarios:
							//Remove the path from PATH and keep searching (which requires some bookkeeping),
							//or just return foundPath as if the check hadn't happened, letting subsequent code throw a BadImageFormatException.
							//We'll just do the latter, at least for now.
						}
					}
					catch { }
					foundPath = pathArray[iPath];
					return false;
				}
			}
		}
		return false;
	}
	private static bool HandleBitnessConflict(ref string pathDirectory, string firstFileName, bool runningWin64, BitnessHelper.Machine fileBitness)
	{
		//Bitness conflict detected. Is this directory in %ProgramFiles%?
		//Bitness-dependent Program Files
		string programFiles = Environment.GetEnvironmentVariable("ProgramFiles");
		//Always points to 32-bit version, if a 64-bit Windows.
		string programFilesX86 = Environment.GetEnvironmentVariable("ProgramFiles(x86)");
		//Always points to 64-bit version, if a 64-bit Windows 7 or greater.
		string programW6432 = Environment.GetEnvironmentVariable("ProgramW6432");
		char[] directoryChars = new[] { Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar };
		if(string.IsNullOrEmpty(programFilesX86))
			return false; //Not Win64, so there won't be two Program Files directories anyway.
		if(string.IsNullOrEmpty(programW6432))
		{
			//Pre-7 Windows version: Try an heuristic.
			int ix = programFilesX86.IndexOf(" (x86)", StringComparison.OrdinalIgnoreCase);
			if(ix < 0) { return false; } //Heuristic failed.
			string exactSubstring = programFilesX86.Substring(ix, " (x86)".Length);
			programW6432 = programFilesX86.Replace(exactSubstring, "");
			if(!Directory.Exists(programW6432)) { return false; } //Heuristic failed.
		}
		if(pathDirectory.StartsWith(programFilesX86) && fileBitness==BitnessHelper.Machine.x86)
		{
			//The file is a 32-bit file in the 32-bit directory in the path;
			//Since there's a conflict, this must mean the current process is 64-bit
			if(!runningWin64) { return false; } //No conflict, no handling.
			string directory64 = Path.Combine(programW6432, pathDirectory.Substring(programFilesX86.Length).TrimStart(directoryChars));
			string filePath64 = Path.Combine(directory64, firstFileName);
			if(Directory.Exists(directory64) && File.Exists(filePath64))
			{
				if(BitnessHelper.RetrieveMachine(filePath64) == BitnessHelper.Machine.x64)
				{
					pathDirectory = directory64;
					return true;
				}
			}
		}
		else if(pathDirectory.StartsWith(programW6432) && fileBitness==BitnessHelper.Machine.x64)
		{
			//The file is a 64-bit file in the 64-bit directory in the path;
			//Since there's a conflict, this must mean the current process is 32-bit
			if(runningWin64) { return false; } //No conflict, no handling.
			string directory32 = Path.Combine(programFilesX86, pathDirectory.Substring(programW6432.Length).TrimStart(directoryChars));
			string filePath32 = Path.Combine(directory32, firstFileName);
			if(Directory.Exists(directory32) && File.Exists(filePath32))
			{
				if(BitnessHelper.RetrieveMachine(filePath32) == BitnessHelper.Machine.x86)
				{
					pathDirectory = directory32;
					return true;
				}
			}
		}
		return false;
	}
