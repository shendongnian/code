        var list = CatSchemeObj.Items.ToList();
        //check before you call it or  you will get an error
        if(!list.Equals(default(list)))
        {
            while(true)
            {
                list = list.Where(x => Array.IndexOf(CatTree, x.Id) > -1);
                list = list.ToList().SingleOrDefault();
                if(list.Equals(default(list))
                {
                    break;
                }
            }
        }
