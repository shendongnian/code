    public async Task SetGridItems(CancellationToken ct, /* and some items */)
    {
        GridItems.clear();
        //get two list of item I want
        var ListA = await getBmethodAsync().AsTask(ct);
        var ListB = await getAmethodAsync().AsTask(ct);
        foreach (itemA A in ListA)
        {
            ct.ThrowIfCancellationRequested();
 
            GridItem i = new GridItem();
            //set name
            i.name = A.Name;
            //get icon
            i.image = img;
            GridItems.Add(i);
        }
        foreach (ItemB b in ListB)
        {
            ct.ThrowIfCancellationRequested();
            GridItem i = new GridItem();
            i.name = b.Name;
            i.image.SetSource(icon);
            GridItems.Add(i);
        }
    }
