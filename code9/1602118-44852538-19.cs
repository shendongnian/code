        InventoryModel invModel = new InventoryModel();
    
        Item model = new Item();
        model.inventorySlot = 1;
        model.itemID = "123ABC";
        model.amount = 234;
    
        Item model2 = new Item();
        model2.inventorySlot = 2;
        model2.itemID = "123ABC";
        model2.amount = 554;
    
        invModel.Items.Add(model);
        invModel.Items.Add(model2);
        
        //Generate JSON then save it
        string yourModelJson = JsonUtility.ToJson(invModel);
        PlayerPrefs.SetString("InventoryKey", yourModelJson);
    
       //Read JSON back to Model
       InventoryModel testModel = new InventoryModel();
       string rawJsonFromPref = PlayerPrefs.GetString("InventoryKey");
       testModel = JsonUtility.FromJson<InventoryModel>(rawJsonFromPref);
