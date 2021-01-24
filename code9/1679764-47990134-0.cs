    int cost = 0;
    Item item;
    while (myReader.Read())
    {
        double.TryParse(myReader["Cost"].ToString(), out cost);
        item = new Item(){Cost = cost};
        list.Add(item);
    }
