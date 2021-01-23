    int price;
    string priceString = ViewState["PricePerCube"].ToString();
	if (int.TryParse(priceString , out price))
	{
	    // code if parse succeeded
	}else{
        // code if parse DID NOT succeed
    }
