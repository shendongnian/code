    string[] fileWords = FC.Split(Separators, StringSplitOptions.RemoveEmptyEntries);
    
    bool hasMatch = false;
    for(string fileWord : fileWords)
    {
        if(Abbreviated.Contains(fileWord))
        {
            hasMatch = true;
            break;
        }
    }
    
    if (hasMatch)
    {
        MessageBox.Show("Match found");
    
    }
    else
    {
        MessageBox.Show("No Match");
    }
