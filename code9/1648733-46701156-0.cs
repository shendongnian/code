	bool green = false;
	bool red = true;
	bool purple = true;
	bool orange = false;
	bool black = true;
	bool blue = true;
	bool brown = false;
	var bools = new Dictionary<string, bool>
	{
		 { $"{nameof(green)}", green}
		,{ $"{nameof(red)}", red}
		,{ $"{nameof(purple)}", purple}
		,{ $"{nameof(orange)}", orange}
		,{ $"{nameof(black)}", black}
		,{ $"{nameof(blue)}", blue}
		,{ $"{nameof(brown)}", brown}
	};
	Console.Write(string.Join("-", bools.Where(b => b.Value).Select(b => b.Key)));
