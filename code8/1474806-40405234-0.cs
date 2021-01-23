    var text = "Morelines\n\nWe have considered the applica\t\r\nnt's experience and qualification, \nand wish to grant him an interview.";
	Console.WriteLine(string.Format("Our text:\n{0}\n---------", text));
    var search = "applicant";
    var pattern = string.Join(@"[\t\r\n]*", search.ToCharArray());
    Console.WriteLine(string.Format("Our pattern: {0}\n----------", pattern));
    var result = Regex.Match(text, pattern);
    if (result.Success) {
       	Console.WriteLine(string.Format("Match: {0} at {1}\n----------", result.Value, result.Index));
       	var lineNo = Regex.Split(text.Substring(0, result.Index), @"\r?\n|\r").GetLength(0);
       	Console.WriteLine(string.Format("Line No: {0}", lineNo));
    }
