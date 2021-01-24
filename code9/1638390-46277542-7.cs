    public static void CalculatePercentagesForID(int id)
    {
        Foo[] rows = db.Table.Where(x => x.ID == id).ToArray();
        
        //... (see the next code block)
    }
