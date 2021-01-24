     static string s = "for(int i = 0; i < 10; i++){ var myVar = \"Test\"; /*commented out code*/ Console.WriteLine(\"stuff\"); /* more comments here*/}//my comments here \n var myOverVar = /*more stuff removed*/ true; //some more comments";
    
     
    static void Main(string[] args)
    {
        //s.IndexOf()
        var result = new List<string>();
        var lines = s.Split(new[] {"\n"}, StringSplitOptions.RemoveEmptyEntries);
        foreach (var line in lines)
        {
            var listOfPositions = new List<int>();
            var l = line;
            //chop off everything after comments
            var indexOfLineComment = l.IndexOf("//");
    
            l = l.Remove(indexOfLineComment + 2);
                    var openBraceIndex = l.IndexOf("/*");
            while (openBraceIndex != -1)
            {
                var closingBraceIndex = l.IndexOf("*/");
                if (closingBraceIndex == -1)
                {
                    break; //you didn't specify how to the case when an error in syntax was made, but handle it here
                }
                l = l.Remove(openBraceIndex + 2, closingBraceIndex - openBraceIndex-2);
                var ind = l.IndexOf("/**/");
                listOfPositions.Insert(0, ind);
                l = l.Remove(ind, 4);
                openBraceIndex = l.IndexOf("/*");
    
            }
            foreach (var i in listOfPositions)
                if (l.Length <= i)
                    l = l + "/**/";
                else
                    l = l.Insert(i, "/**/");
            result.Add(l);
        }
    
    }
