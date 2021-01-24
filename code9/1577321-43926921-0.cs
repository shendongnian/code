    IList<string> compute()
    {
        if (this.isCommaSeperated)
        {
            return contents.Split(",");  // No need to turn the array into a list
        }
        return new[] { contents };   
    }
