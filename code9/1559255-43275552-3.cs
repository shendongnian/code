    static void Main(string[] args)
    {
        TreeList T1 = new TreeList("");
        TreeList T2 = new TreeList("");
        TreeList T3 = new TreeList("");
        T1.Add(T2);
        T2.Add(T3);
        bool result = Contains(T1, T2); // test 1- true
        bool result2 = Contains(T2, T1); // test 2 - false
        bool result3 = Contains(T3, T2); // test 3 - false
    }
    public static bool Contains(TreeList source, TreeList searchedElement)
    {
         if (source.Equals(searchedElement) || source.Items.Contains(searchedElement))
             return true;
                      
         foreach (TreeList tList in source.Items)
         {
             if (tList.Items.Count > 0 && Contains(tList, searchedElement))
                 return true;
         }
         
         return false;
     }
