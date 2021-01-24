	interface DataLinesProvider {
		IEnumerable <DataLine> Lines ();
	}
	class DataLinesFile implements DataLinesProvider {
		private readonly string _fileName;
		// constructor
		////////////////////
		IEnumerable <DataLine> Lines () {
			// not sure that it's right
			return File
				. ReadAllLines (_fileName)
				.Select (x => new DataLine (x));
		}
	}
