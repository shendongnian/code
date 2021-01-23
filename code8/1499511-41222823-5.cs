    string sentence = "Hello World <Red>This is some red text </Red> This is normal <Blue>This is blue text </Blue>";
    string[] matchSegments = Regex.Split(sentence,@"(<\w+>)(.*?)<\/\w+>");
    foreach (string value in matchSegments)
    {
        if(value.Contains("<") && value.Contains(">"))
            Console.Write(value);
        else
            Console.WriteLine(value);	
    }
