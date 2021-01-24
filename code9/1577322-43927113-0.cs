    dynamic Compute(bool isCommaSeperated)
    {
        if(isCommaSeperated)
        {
            return contents.Split(",").ToList();
        }
        else
        {
            return contents;
        }
    }
