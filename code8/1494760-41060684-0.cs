    public static Tuple<string, double> MethodName ( string A, string B, double n1, double n2, double n3)
    {
       double sum;
    
       Console.Write(A);
    
       Console.Write(B);
    
       sum= n1+n2+n3;
    
       return new Tuple<string, double>("yourString", sum);
    }
