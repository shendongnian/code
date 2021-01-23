	static void DeleteLines(string filename, string searchText) {
		// Obtain the filtered lines
		var filteredLines = File.ReadLines(filename).Where(line => !line.Contains(searchText) /* You can use case insensitive match, regex matching, etc here */ );
		// Create a temp file to store the filtered lines. You can do it in memory, if you know that the file is small
		string destFilename = Path.GetTempFileName();
		File.WriteAllLines(destFilename, filteredLines);
		// Now overwrite the original file with the filtered lines
		File.Delete(filename);
		File.Move(destFilename, filename);
	}
	static void Main(string[] args) {
		DeleteLines("Test.txt", "English");
	}
