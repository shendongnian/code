	static void DeleteLines(string filename, string searchText) {
		bool searchTextFound = false;
		// Obtain the filtered lines
		var filteredLines = File.ReadLines(filename).Where(line => !(searchTextFound = line.Contains(searchText)) /* You can use case insensitive match, regex matching, etc here */ );
		if (searchTextFound) {
			// Create a temp file to store the filtered lines. You can do it in memory, if you know that the file is small
			string destFilename = Path.GetTempFileName();
			File.WriteAllLines(destFilename, filteredLines);
			// Now overwrite the original file with the filtered lines
			File.Delete(filename);
			File.Move(destFilename, filename);
		} else {
			Console.WriteLine($"Search Text '{searchText}' not found");
		}
	}
	static void Main(string[] args) {
		DeleteLines("Test.txt", "English");
	}
