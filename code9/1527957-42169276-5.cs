    void generateJson()
    {
        Item[] item = new Item[2];
    
        item[0] = new Item();
        item[0].Name = "Potion";
        item[0].Id = 1;
        item[0].Balance = 5;
    
        item[1] = new Item();
        item[1].Name = "Neutral Bomb";
        item[1].Id = 2;
        item[1].Balance = 4;
    
        string value = JsonHelper.ToJson(item, true);
        Debug.Log(value);
    }
