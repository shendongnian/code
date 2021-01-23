    string[] result = new string[4];
    
    int groups = input.Length / 3;
    if (groups > 3) groups = 3;
    int group;
    for (group = 0; group < groups; group++)
    {
        result[group] = input.Substring(group*3, 3);
    }
    // Assert: group < 4
    result[group] = input.Substring(group*3);
    // Assert: answers in result[0..groupCount-1]
    int groupCount = group+1;
