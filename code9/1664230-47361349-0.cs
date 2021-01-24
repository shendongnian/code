        int N,S,E,W,Total;
        Console.Write("Enter North : ");
        N=int.Parse(Console.Readline());
    
        Console.Write("Enter South: ");
        S=int.Parse(Console.Readline());
      
        Console.Write("Enter East: ");
    
        E=int.Parse(Console.Readline());
        
        Console.Write("Enter West: ");
        W=int.Parse(Console.Readline());
        
        if(N > S)
           Total = N-S;
        else
           Total = S-N;
        
        if(E > W)
           Total += (E-W)
        else
           Total += (W-E)
        Console.Write("Final Total Step are : "+Total);
