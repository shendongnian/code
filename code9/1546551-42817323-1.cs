    string input = ReadInput();
    var moves = input.Replace(" ", "").ToCharArray();
    foreach(char move in moves)
    {
        switch(move)
        {
            case 'F': 
                MoveForwards();
                break;
            case 'R': 
                MoveBackwards();
                break;
            //etc...
        }
    }
