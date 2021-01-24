    string pattern = @"\[[?>\[[?<c>]|[^[]]+|\][?<-c>]]*[?[c][?!]]\]";
	string testString = "[[0]] test string vali[1][[-22]]";
	int count = testString.Split('[').Length - 1;
	MatchCollection matches = Regex.Matches(testString,pattern);
	Console.WriteLine("Matches {0}",matches.Count);
	Console.WriteLine("Count {0}", count);
	if(count == matches.Count){
		  Console.WriteLine("Valid");
	}
	else{
		  Console.WriteLine("Invalid");
	}
