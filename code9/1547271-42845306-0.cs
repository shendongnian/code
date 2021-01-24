    using System;
    using System.Collections.Generic;
    
    namespace Program {
    	class _Main {
    		// Initialize dictionary with values
    		static Dictionary<string, string> dictionaryWithStrings = new Dictionary<string, string> { 
    			{ "NumberOfItemsInArray", "2" },
    			{ "Item1-Name", "Some name" },
    			{ "Item1-Price", "0.5$" },
    			{ "Item1-DiscountRate", "?%" },
    			{ "Item1-Category", "Some category" },
    			{ "Item2-Name", "Other name" },
    			{ "Item2-Price", "4$" },
    			{ "Item2-DiscountRate", "24%" },
    			{ "Item2-Category", "Other category" }
    		};
    		// Create *dynamic* list with Item's
    		static List<Item> objects = new List<Item>();
    		static void Main() {			
    			// "- 1" removes the NumberOfItemsInArray from count
    			// "/ 4" Since you have always 4 strings
    			for (int i = 1; i <= (dictionaryWithStrings.Count - 1) / 4; i++) {
    				objects.Add(new Item {
    					Name = dictionaryWithStrings["Item"+i+"-Name"],
    					Price = dictionaryWithStrings["Item"+i+"-Price"],
    					DiscountRate = dictionaryWithStrings["Item"+i+"-DiscountRate"],
    					Category = dictionaryWithStrings["Item"+i+"-Category"] 
    				});
    			}
    			Console.WriteLine("objects contains [" + objects.Count + "] items, values:");
    			foreach (Item item in objects) {
    				Console.WriteLine("Item id: [" + objects.IndexOf(item) + 
    					"], Name: [" + item.Name +
    					"], Price: [" + item.Price + 
    					"], DiscountRate: [" + item.DiscountRate + 
    					"], Category: [" +item.Category + "]"
    				);
    			}
    		}
    		struct Item {
    			public string Name;
    			public string Price;
    			public string DiscountRate;
    			public string Category;
    		}
    	}
    }
        
