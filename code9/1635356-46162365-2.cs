    delegate string InnerDel();
    delegate InnerDel OuterDel();  // this one returns an instance of Inner delegate
    
    public static void Main()
    {
        OuterDel myOuterDelegate = () =>
        {
            InnerDel myInnerDel = () => { return "inside"; };
            return myInnerDel;
        };
    
        InnerDel k = myOuterDelegate();
    
        k();
    }
