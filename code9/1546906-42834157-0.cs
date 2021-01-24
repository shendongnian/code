    string llist2 = "1,12,123,23,21";
    int numtorem1 = 1;
    int numtorem2 = 123;
    int numtorem3 = 21;
    int numtorem4 = 2;
    
    //m.Groups[1].Value is string.Empty or ","
    Console.WriteLine(Regex.Replace(llist2,
                        string.Format("^{0},|,{0}(,)|,{0}$", numtorem1),
                        m => m.Groups[1].Value));
    //ouput 12,123,23,21
    
    Console.WriteLine(Regex.Replace(llist2,
                        string.Format("^{0},|,{0}(,)|,{0}$", numtorem2),
                        m => m.Groups[1].Value));
    //ouput 1,12,23,21
    
    Console.WriteLine(Regex.Replace(llist2,
                        string.Format("^{0},|,{0}(,)|,{0}$", numtorem3),
                        m => m.Groups[1].Value));
    //ouput 1,12,123,23
    
    Console.WriteLine(Regex.Replace(llist2,
                        string.Format("^{0},|,{0}(,)|,{0}$", numtorem4),
                        m => m.Groups[1].Value));
    //ouput 1,12,123,23,21
