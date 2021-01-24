    var str = "A tab\there \"inside\ta\tdouble-quoted\tsubstring\" some\there";
	var pattern = "\"[^\"]+\""; // A pattern to match a double quoted substring with no escape sequences
    var result = Regex.Replace(str, pattern, m => 
    		m.Value.Replace("\t", "-")); // Replace the tabs inside double quotes with -
    Console.WriteLine(result);
    // => A tab	here "inside-a-double-quoted-substring" some	here
