    string Pattern = "\d+\/"; //Decimals, followed by a slash
    string input = Console.ReadLine();
    string topWS = Regex.Match(Pattern, input).Value //Will be something like 32/
    string top = topWS.Value.Substring(0, topWS.Length - 1) //Will be 32
    string bottom = input.Substring(topWS.Length)
    Console.WriteLine(double.Parse(top) / double.Parse(bottom));
    //Will return the fraction decimal value.
    
