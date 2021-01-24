        bool result = Contains(T1, T2);
    
        public static bool Contains(TreeList source, TreeList searchedElement)
        {
             if (source.Items.Contains(searchedElement))
                 return true;
             else
             {
                 foreach (TreeList tList in source.Items)
                 {
                    if (tList.Items.Count > 0 && Contains(tList, searchedElement))
                            return true;
                 }
             }
             return false;
         }
