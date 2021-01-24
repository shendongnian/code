    Regex testRegex = new Regex(@"\[[?>\[[?<c>]|[^[]]+|\][?<-c>]]*[?[c][?!]]\]", RegexOptions.IgnorePatternWhitespace);
    string testString = "[[0]] test string vali[1][[-22]]";
    int count = testString.Split('[').Length - 1;
    MatchCollection matches = testRegex.Matches(testString);
    Console.WriteLine("Matches {0}",matches.Count);
    Console.WriteLine("Count {0}", count);
    if(count == matches.Count){
	Console.WriteLine("Valid");
    }
    else{
	Console.WriteLine("Invalid");
    }
