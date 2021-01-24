    static void Method(string word, ref string[] tab)
    {
        string [] tab1;
        [..] 
        tab = tab1; // tab changes to tab1
    }
    static void Main(string[] args)
    {
         string[]  tab = { "", "", "", "", "", "", "", "", "", "" };
         Method("443", ref tab);
         //and here tab does not change like I though it would.
     }
