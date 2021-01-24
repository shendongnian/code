    private void Example()
    {
        string[] lines = {"A|3232|test",
                          "C|5544|test2",
                          "C|8884|test3",
                          "A|7777|test0",
                          "A|4343|test4"};
    
        List<string> aletterlines = new List<string>();
        List<string> CletterLines = new List<string>();
    
        foreach (string item in lines)
        {
            if (item.StartsWith("A"))
            {
                aletterlines.Add(item);
            }
            else if (item.StartsWith("C"))
            {
                CletterLines.Add(item);
            }
        }
    }
