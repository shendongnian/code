    List<string> productsAll = new List<string>();
	productsAll.Add("CMT_40");
	productsAll.Add("CMT_50");
	productsAll.Add("Mortar");
	productsAll.Add("Mortar");
	productsAll.Add("Mortar");
	string itemToRemove = "Mortar";
	
    productsAll.RemoveAll(x=>x==itemToRemove);	
