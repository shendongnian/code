    string output = "";
    
    for (int i = 0; i < contentArr.Length; i++)
    {
        output += characterList[i] + " = " + valueList[i] + Environment.NewLine;
    }
    
    File.WriteAllText(@"C:\test.txt", output);
