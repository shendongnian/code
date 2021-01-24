    private static void Slider2()
		{
			var _FileContents = File.ReadAllLines("<path>");
			var previousLine = string.Empty;
			var lineBeforePrevious = string.Empty;
			foreach (var line in _FileContents)
			{
				// do something with line, previousLine and lineBeforePrevious
				// put some conditions around this
				lineBeforePrevious = previousLine;
				// put some conditions around this
				previousLine = line;
			}
		}
