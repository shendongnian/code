	var panmaskednumber = "543034******0243";
	var count = panmaskednumber.Count(x => x == '*');
	var start = panmaskednumber.IndexOf('*');	
	var replace = "123456789";
    // output 5430341234567890243 (543034 123456789 0243)
	Console.WriteLine(panmaskednumber.Remove(start)
                    + replace
                    + panmaskednumber.Substring(start + count));
     // output 5430341234560243 (543034 123456 0243)
     Console.WriteLine(panmaskednumber.Remove(start)
					+ replace.Remove(count)
					+ panmaskednumber.Substring(start + count));
