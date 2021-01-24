    LetterAA aa = new LetterAA();
    LetterAB ab = new LetterAB();
    Foo foo = new Foo();
    
    bool isAA = IsLetter(aa);
    bool isAB = IsLetter(ab);
    bool isLetter = IsLetter(foo);
    
    Console.WriteLine(isAA); // True
    Console.WriteLine(isAB); // True
    Console.WriteLine(isLetter); // False
