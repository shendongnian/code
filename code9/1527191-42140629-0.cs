    static string[] GetSentences(string filePath) {
			if (!File.Exists(filePath))
				throw new FileNotFoundException($"Could not find file { filePath }!");
			var lines = string.Join("", File.ReadLines(filePath).Where(line => !string.IsNullOrEmpty(line) && !string.IsNullOrWhiteSpace(line)));
			var sentences = Regex.Split(lines, @"\.[\s]{1,}?");
			return sentences;
		}
