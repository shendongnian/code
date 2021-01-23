    for(int y = length - 1; y>=0; y--) //length = number of digits
    {
        for(int x = 0; x < 3; x++){
           string n = num[x].ToString(); //converting the array to string 
                 Console.Write(n[y] + "\n");
            }
    }
