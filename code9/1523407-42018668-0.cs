    List<string> input = new List<string>(){"a","b","c","d","*","e","f","*","g"};
    List<List<string>> result = new List<List<string>>();
    List<string> temp = new List<string>();
    foreach (string item in input)
    {
        if (item == "*")
        {
            result.Add(temp);
            temp = new List<string>();
        }
        else
        {
            temp.Add(item);
        }
    }
    result.Add(temp);
