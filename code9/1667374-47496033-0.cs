    long count;
    string x = "";
    string y = "";
    string[] arr2 = new string[100000000];
    for (int i = 1; i < arr2.Length; i++)
    {
        arr2[i - 1] = i.ToString();
    }    
    for (var i = 0; i < arr2.Length; i++)
    {
        var s = arr2[i];
    
        if (s == null)
            continue;
    
        for (var j = 0; j < s.Length; j++)
        {
            if (s[j] == '2')
                count++;
        }
    }
