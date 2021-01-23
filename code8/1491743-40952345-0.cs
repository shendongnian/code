    var numbers = "0123456789.-".ToCharArray();
    if(line.EndsWith("2"))
    {
        // Get the index of the first non-letter character after the name
        var index = line.IndexOfAny(numbers, 1);
        var name = line.SubString(1, index - 1);
        MessageBox.Show(name); 
    }
