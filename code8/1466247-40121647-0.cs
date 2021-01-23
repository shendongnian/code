    //declare the array
    int[] A = new int[10];
    Console.Write("input ISBN:");
    
    //Read the isbn from the console
    string input = Console.ReadLine();
    //turn that into a char array
    char[] characters = input .ToCharArray();
     
    StringBuilder sb = new StringBuilder();
    sb.append("ISBN: ");
    //iterate
    for (int i = 0; i < characters.Length; i++)
    {
        sb.append(characters[i]).append(" "); 
    }
    //print it
    Console.WriteLine(sb);
