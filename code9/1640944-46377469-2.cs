    string string1 = "My Name is Something. I do nothing tessst";
    string string2 = "My Name is Momething. I do othing";
    
    //Trasnforme string to list with space like separator, and compare string by position
    var List1 = string1.Split(' ').Select((valuestring1, index) => new { valuestring1, index });
    var List2 = string2.Split(' ').Select((valuestring2, index) => new { valuestring2, index });
    
    //Left outer join
    var leftdifference = from word1 in List1
                         from word2 in List2.Where(word2 => word1.index == word2.index).DefaultIfEmpty()
                         where word2 == null || word1.valuestring1 != word2.valuestring2
                         select new { word1, word2 };
    
    //Right outer join
    var rightdifference = from word2 in List2
                          from word1 in List1.Where(word1 => word1.index == word2.index).DefaultIfEmpty()
                         where word1 == null || word1.valuestring1 != word2.valuestring2
                          select new { word1, word2 };
    
    var fulldifference = leftdifference.Union(rightdifference).ToList();
    
    foreach (var item in fulldifference)
    {
        string val1 = item.word1 == null ? "NOT PRESENT WORD" : item.word1.valuestring1;
        string val2 = item.word2 == null ? "NOT PRESENT WORD" : item.word2.valuestring2;
        int index = item.word1 == null ? item.word2.index : item.word1.index;
    
        Console.WriteLine("position {0}, string1 : '{1}' , string2 : '{2}'", index, val1, val2);
    }
