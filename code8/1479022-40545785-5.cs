        var list = CatSchemeObj.Items.ToList();
        //check before you call it or  you will get an error
        if(!list.Equals(default(list)))
        {
            while(true)
            {
                var temp = list.Where(x => Array.IndexOf(CatTree, x.Id) > -1);
                list = temp.Items.ToList().SingleOrDefault();
                if(list.Equals(default(list))
                {
                    break;
                }
            }
        }
