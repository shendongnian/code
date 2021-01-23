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
    //use this recursive function outside of loop because it will cat itself
    void CleanTheCat(List<string> CatTree)
    {
        CatTree.RemoveAll(x => x.Id != Cat.ToString());
        var cat = CatTree.Items.ToList().SingleOrDefault();
        if (!cat.Equals(default(cat)){
            CleanTheCat(cat);
        }
    }
