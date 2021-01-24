    //source string
    string input = "12-12-3451-1";
    //remove wrong dashes first
    input = input.Replace("-", "");
    
    //loop all characters in the string, doing this in a loop prevents index out of range
    //exception when string it shorter that 9
    for (int i = 0; i < input.Length; i++)
    {
        //insert the appropriate dashes
        if (i == 2 || i == 8 || i == 10)
        {
            input = input.Insert(i, "-");
        }
    }
    
    //show results
    Label1.Text = input;
