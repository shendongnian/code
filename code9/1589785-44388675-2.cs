    var s = @"<?xml version=""1.0""?>
	  <root>
		<Part>this is sample part</Part>
	    <Remarks>this is sample remark</Remarks>
	    <Notes>this is sample notes</Notes>
	    <Desc>sample</Desc>
	  </root>";
    var document = XDocument.Parse(s);
    var names = document.Descendants()
                   .Elements()
                   .Where(x => x.Value.Contains("sample")) // all nodes with text having sample
                   .Select(a => a.Name.LocalName); // return the local names of the nodes
    Console.WriteLine(string.Join("\n", names));
