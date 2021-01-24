    int i=0;
    while (true)
    {
        int row = i % height;
        int column = i / height;
        
        string word = words[row];
        
        if (column < word.Length)
        {            
            var c = words[row][column];
        
            Console.SetCursorPosition(column, row);
            Console.Write(c);
        }
        else
        {
            // etc
        }
        
        i++;
    }
