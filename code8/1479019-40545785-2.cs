    //solution 1
    // inside of this loop check each child list if empty or not
    foreach (var Cat in CatTree)
    {
        var list = CatSchemeObj.Items.ToList();
        //check before you call it or  you will get an error
        if(!list.Equals(default(list)))
        {
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
    }
    //solution 2
    foreach (var Cat in CatTree)
    {
        var list = CatSchemeObj.Items.ToList();
        //check before you call it or  you will get an error
        if(!list.Equals(default(list)))
        {
            CleanTheCat(cat, list);
        }
    }
    //use this recursive function outside of loop because it will cat itself
    void CleanTheCat(string cat, List<typeof(ICategorySchemeMutableObject.Items) /*Place here whatever type you have*/> CatSchemeObj)
    {
        CatSchemeObj.RemoveAll(x => x.Id != cat);
        var catObj = CatSchemeObj.Items.ToList().SingleOrDefault();
        if (!catObj.Equals(default(catObj)){
            CleanTheCat(cat, catObj);
        }
    }
