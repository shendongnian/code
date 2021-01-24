	var panmaskednumber = "543034******0243";
	var count = panmaskednumber.Count(x => x == '*');
	var start = panmaskednumber.IndexOf('*');	
	var replace = "123456789";
    // output 5430341234567890243 (543034 123456789 0243)
	Console.WriteLine(panmaskednumber.Remove(start) // get head
                    + replace // add replace
                    + panmaskednumber.Substring(start + count)); // add tail
     // output 5430341234560243 (543034 123456 0243) // get head 
     Console.WriteLine(panmaskednumber.Remove(start)
					+ replace.Remove(count) // add replace with count respect
					+ panmaskednumber.Substring(start + count)); // add tail
     replace = "123";
     // output 543034123***0243 (543034 123*** 0243) // get head 
     Console.WriteLine(panmaskednumber.Remove(start)
                    + replace // add replace
				    + new string('*', count - replace.Length) // fill with missing *
                    + panmaskednumber.Substring(start + count)); // add tail
