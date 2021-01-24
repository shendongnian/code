    void Main()
    {
    	List<Product> products = new List<Product> { 	new Product { ProductID = 1, Quantity = 5 },
    													new Product { ProductID = 2, Quantity = 5 },
    													new Product { ProductID = 3, Quantity = 8 },
    													new Product { ProductID = 4, Quantity = 15 },
    													};
    
    
    	decimal requiredQuantity = 15;
    	if (requiredQuantity < products.Sum(p => p.Quantity))
    	{
    		var output = Permutations(products, requiredQuantity);
    
    		output.Dump();
    	}
    	else
    	{
    		products.Dump();
    	}
    }
    
    // Define other methods and classes here
    private List<Queue<Product>> Permutations(List<Product> list, decimal requiredValue, Stack<Product> currentList = null)
    {
    	if (currentList == null)
    	{
    		currentList = new Stack<Product>();
    	}
    	List<Queue<Product>> returnList = new List<System.Collections.Generic.Queue<Product>>();
    	
    	foreach (Product product in list.Except(currentList))
    	{
    		currentList.Push(product);
    		decimal currentTotal = currentList.Sum(p => p.Quantity);
    		if (currentTotal >= requiredValue)
    		{
    			//Stop Looking. You're Done! Copy the contents out of the stack into a queue to process later. Reverse it so First into the stack is First in the Queue
    			returnList.Add(new Queue<Product>(currentList.Reverse()));
    		}
    		else
    		{
    			//Keep looking, the answer is out there
    			var result = Permutations(list, requiredValue, currentList);
    			returnList.AddRange(result);
    		}
    		currentList.Pop();	
    	}
    	
    	
    	return returnList;
    }
    
    
    struct Product
    {
    	public int ProductID;
    	public int Quantity;
    }
