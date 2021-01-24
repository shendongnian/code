    RootOb rr = JsonUtility.FromJson<RootOb>(octojson);
    List<Result> result = rr.results;
    //Loop through the Results List
    for (int i = 0; i < result.Count; i++)
    {
        //Get each item
        Item item = result[i].item;
        Debug.Log("Item Index: " + i + "...  mpn: " + item.mpn);
    
        //Loop through the Offer List
        for (int j = 0; j < item.offers.Count; j++)
        {
            //Get each offer
            Offer offer = item.offers[j];
            Debug.Log("Offer Index: " + j + "....  quantity: " + offer.in_stock_quantity);
        }
    }
