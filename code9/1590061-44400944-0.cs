    string myString = "12343";
    var sortedChar = myString.ToCharArray().ToList(); //we convert string to character
    
                sortedChar.Sort(); //this two lines is equivalent to OrderBy
    
                string sortedString =string.Join("",sortedChar);//this code concat the character or string together with specified string(here "")
                if (sortedString == myString)
                {
                    Console.WriteLine("it's sorted.");
    
                }
                else
                {
                    Console.WriteLine("it's not sorted.");
    
                }
