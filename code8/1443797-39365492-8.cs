    if (textBox_DEC_Search.Text.All(x => Char.IsNumber(x)))
    {
        Debug.WriteLine("Number");
        // search through ID
    }
    else
    {
        Debug.WriteLine("Name");
        // search through Name
    }
