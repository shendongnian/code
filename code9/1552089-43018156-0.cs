    void Main()
    {
    	var basket = new List<string>
    	{
    		"Cake",
    		"Cake",
    		"Apples",
    		"Bananas",
    		"Cake",
    		"Cookies",
    		"Cake"
    	};
    
    	GenerateReceipt(basket);
        // Output:
        // 4x ................ Cake
        // 1x ................ Apples
        // 1x ................ Bananas
        // 1x ................ Cookies
    }
    
    static void GenerateReceipt(List<string> basket) {
    	var groupedBasket = basket.GroupBy(b => b);
    
    	foreach (var item in groupedBasket) {
    		Console.WriteLine($"{item.Count()}x ................ {item.Key}");
    	}
    }
