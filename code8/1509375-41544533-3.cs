    string[] result = new string[4];
    
    int groups = input.Length / 3;
    if (groups > 3) groups = 3;
    int group;
    for (group = 0; group < groups; group++)
    {
        result[group] = input.Substring(group*3, 3);
    }
    // group < 4
    result[group] = input.Substring(group*3);
