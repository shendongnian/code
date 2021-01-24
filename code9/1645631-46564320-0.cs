    //Initializing the elements
    int a = 0;
    int b = 1;
    int c = 1;
    
    Console.WriteLine(a); //Typing the 0'th element
    Console.WriteLine(b); //Typing the first element
    
    for(;c <= 34; c = a + b) {
        Console.WriteLine(c); //Typing the actual element
        a = b;
        b = c;
    }
