    public List<string> PrintResult()
    {
        var listItems = new List<string>();
        if (1 == 1)
        {
            listItems.Add("equal 1");
            if (2 == 2)
            {
                listItems.Add("equal 2");
            }
        }
        else
        {
            listItems.Add("error");
        }
        return listItems;
    }
