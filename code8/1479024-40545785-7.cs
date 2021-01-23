        int counter = 0;
        var list = CatSchemeObj.Items.ToList();
        //check before you call it or  you will get an error
        if(!list.Equals(default(list)))
        {
            while(true)
            {
                var temp = list.Where(x => CatTree[counter++] == x.Id); // or != ? play with it .
                list = temp.Items.ToList().SingleOrDefault();
                if(list.Equals(default(list))
                {
                    break;
                }
            }
        }
