    Console.WriteLine("".Length); // => 2
	Console.WriteLine(new StringInfo("").LengthInTextElements); // => 1
	var myString = @"This is a string before an emoji:This is after the emoji.";
	var teMyString = new StringInfo(myString);
	Console.WriteLine(teMyString.SubstringByTextElements(0, 33));
    // => "This is a string before an emoji:"
	Console.WriteLine(teMyString.SubstringByTextElements(0, 34));
    // => This is a string before an emoji:
	Console.WriteLine(teMyString.SubstringByTextElements(0, 35));
    // => This is a string before an emoji:T
