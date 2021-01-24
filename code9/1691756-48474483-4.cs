    string ouput = "";
    
    for (int i = 0; i < contentArr.Length; i++)
    {
        output += characterList[i] + " = " + valueList[i]);
    }
    
    File.WriteAllText(@"C:\test.txt", ouput);
