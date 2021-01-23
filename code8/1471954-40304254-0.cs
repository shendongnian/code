    public Product(string cat)
    {
        //Validate that the category passed in is valid, I.E. in your list
        foreach (var item in category)
        {
            if(object.Equals(item, cat))
                break;
            if(object.Equals(item, category.Last()))
                throw new Exception("D'oh! Invalid category");
        }
        //do stuff
    }
