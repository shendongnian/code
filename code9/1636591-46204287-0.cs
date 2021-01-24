    {
       //this is the main method.
       //Assuming 'ecrCategories' is list of Categories
       getparent(child2, ecrCategories);
	   Console.WriteLine(str.Trim(','));
    }
        
    static string str = "";
    static void getparent(Category cat, List<Category> listtocheck )
    {
        foreach (var item in listtocheck)
        {
            if (item.Children == null) continue;
            if (item.Children.Count>0  )
            {
                str += item.Name + ",";
                getparent(item, item.Children);
            }
        }
    }
