	using(var webClient = new System.Net.WebClient()){
		var jsonString = webClient.DownloadString("http://cncpts.com/products.json");
		ProductsJsonModel Data = JsonConvert.DeserializeObject<ProductsJsonModel>(jsonString);
		List<Product> ProductsFromUrl = Data.products; // All of your products are here.
	}
	
