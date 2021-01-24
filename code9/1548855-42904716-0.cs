    using System.Text;
    var line = "\"Mark, Fenech\", \"20\", \"170\"";
    public static string RemoveColumnDelimiterInsideValues(string input) {
		
		const char valueDelimiter = '"';
		const char columnDelimiter = ',';
		
        StringBuilder output = new StringBuilder();
		
        bool isInsideValue = false;
		for (var i = 0; i < input.Length; i++) {
			
			var currentChar = input[i];
			if (currentChar == valueDelimiter) {
				isInsideValue = !isInsideValue;
				output.Append(currentChar);
				continue;
			}
			if (isInsideValue) {
				if (currentChar != columnDelimiter ) {
					output.Append(currentChar); 
				}
                // else ignore columnDelimiter inside value
			}
			else {
				output.Append(currentChar);
			}
		}
		return output.ToString();
	}
