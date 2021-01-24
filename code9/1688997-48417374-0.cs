    UpdateSession uSession = new UpdateSession();
    IUpdateSearcher uSearcher = uSession.CreateUpdateSearcher();
    uSearcher.Online = false;
    ISearchResult sResult = uSearcher.Search("IsInstalled=1 And IsHidden=0");
    Console.WriteLine("Found " + sResult.Updates.Count + " updates" + Environment.NewLine);
       foreach (IUpdate update in sResult.Updates)
       {
              Console.WriteLine();
              Console.WriteLine("Required update " + update.KBArticleIDs[0].ToString() + " is installed...");
              Console.WriteLine("Update ID = "+update.Identity.UpdateID);
              ICategoryCollection icc = update.Categories;
              foreach (ICategory ic in icc)
              {
                Console.WriteLine("Patch description = " + ic.Description.ToString());
                Console.WriteLine("Patch category = " + ic.CategoryID.ToString());
                Console.WriteLine("Patch Type = " + ic.Type.ToString());
                Console.WriteLine("Patch name = " + ic.Name.ToString()); 
    // only first ICategory element stores the patch name,
    // which reveals the Classification information
              }
       }
