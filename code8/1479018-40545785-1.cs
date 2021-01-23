    //solution 1
    // inside of this loop check each child list if empty or not
    foreach (var Cat in CatTree)
    {
        var list = CatSchemeObj.Items.ToList();
        while(true)
        {
            list.RemoveAll(x => x.Id != Cat.ToString());
            list = list.ToList().SingleOrDefault();
            if(list.Equals(default(list))
            {
                break;
            }
        }
    }
    //solution 2
    foreach (var Cat in CatTree)
    {
        CleanTheCat(cat, CatSchemeObj);
    }
    //use this recursive function outside of loop because it will cat itself
    void CleanTheCat(string cat, ICategorySchemeMutableObject CatSchemeObj)
    {
        CatSchemeObj.RemoveAll(x => x.Id != cat);
        var catObj = CatSchemeObj.Items.ToList().SingleOrDefault();
        if (!catObj.Equals(default(catObj)){
            CleanTheCat(cat, catObj);
        }
    }
