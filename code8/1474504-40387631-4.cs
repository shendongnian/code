    List<string> A;
    List<string> B;
    
    List<string> aCopy = new List(A);
    
    foreach(string s in aCopy)
    {
        if (B.Contains(s))
        {
            A.Remove(s);
            B.Remove(s);
        }
    }
    
    //Whats in A are whats missing in B
    //Whats in B are whats missing in A
