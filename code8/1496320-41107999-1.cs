    private void fillListbox_Click(object sender, EventArgs e)
    {
        beerlistBox.Items.Clear();
        dbbeer.DatabaseConnect();
        List<Beer> beerList = dbbeer.ReadBeers();
        foreach (Beer beer in beerList)
        {
            beerlistBox.Items.Add(beer.name); // use the property "name"
        }
        dbbeer.DatabaseDisconnect();
    }
     
