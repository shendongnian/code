    string text = File.ReadAllText(@"C:\users\sjors\desktop\in.txt");
    string[] values = text.Split('|');
                           
    StringBuilder SB = new StringBuilder();
                
    for(int i = 0; i < values.Length; i++)
    {
        if ( i + 1 % 3 == 0 )
            values[i] = values[i].Replace("\r\n", " ");
        SB.Append(values[i] + "|");
    }
    
    // Trim end to remove the trailing |
    File.WriteAllText(@"C:\users\sjors\desktop\out.txt", SB.ToString().TrimEnd('|'));
