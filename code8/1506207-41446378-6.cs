    public class Version : IComparable<Version> {
        // Just guessing here - without knowing the actual format
		public int Major = 0;
		public int Minor = 0;
		public int Build = 0;
		public string FileName;
		
		public Version(string fileName) {
			ParseFileName(fileName);
		}
		
        // Split the string on '_' or '.',
        // Considers the first 3 numbers to be version
        // (stops parsing at non-numeric value)
		public void ParseFileName(string fileName) 
		{
			FileName = fileName;
			string [] data = Regex.Split(fileName, @"[_\.]");
			int x;
			if (Int32.TryParse(data[0], out x)) {
				Major = x;
				if (2 <= data.Length && Int32.TryParse(data[1], out x)) {
					Minor = x;
					if (3 <= data.Length && Int32.TryParse(data[2], out x)) {
						Build = x;
					}
				}
			}
		}
		
		public override string ToString() {
			return FileName;
		}
		
        // Comparison
		public int CompareTo(Version v) {
        	int c = Major.CompareTo(v.Major);
        	if (0 == c) {
        		c = Minor.CompareTo(v.Minor);
        	}
        	if (0 == c) {
        		c = Build.CompareTo(v.Build);
        	}
        	return c;
    	}
	}
