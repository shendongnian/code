    if (!results.Items.First<Item>().Id.Equals(anchorId))
    {
        Console.Writeline("The collection has changed while paging. " + 
        "Some results may be missed.");
    }
