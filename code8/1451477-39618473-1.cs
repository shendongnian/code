    var position = "l=50; r=190; t=-430; b=-480";
    var parts = position.Split(';'); // split string into 4 parts
    var assignments = new Dictionary<string, int>();
    
    foreach (var part in parts)
    {
    	var trimmedPart = part.Trim();
    	var assignmentParts = trimmedPart.Split('='); // split each part into variable and value part
    	var value = Int32.Parse(assignmentParts[1]); // convert string to integer value
    	assignments.Add(assignmentParts[0], value);
    }
    
    // change values
    assignments["t"] = -505;
    assignments["b"] = -555;
    
    // build new string
    var newPosition = String.Join("; ", assignments.Select(p => p.Key + "=" + p.Value));
    Console.WriteLine(">> " + newPosition);
