    string str = "Bbox(x1: 750; y1: 300; x2: 1100; y2: 600)";
    var keyValuePairs = str.Split('(', ')')[1] // get what inside of the parentheses
    				.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries) // split them into {key:value}
    			    .Select(part => part.Split(':'))
    			    .ToDictionary(split => split[0].Trim(), split => int.Parse(split[1].Trim()));
