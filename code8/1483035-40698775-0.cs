    struct MyWreck
    		{
    			public int Id;
    			public string Desc;
    		}
    		static int itemCount = 10;
    		static MyWreck[] items = new MyWreck[10];
    
    		public static void PrepareArray()
    		{
    			var seed = 400;
    			for (var i = 0; i < itemCount; i++)
    			{
    				items[i] = new MyWreck { Id = seed + i, Desc = "Description " + i };
    			}
    
    		}
    
    		public static void DeleteFromArray()
    		{
    
    			PrepareArray();
    
    			Console.Write("Please enter an item ID No: ");
    			string id = Console.ReadLine();
    			int itemidnotodelete = int.Parse(id);
    			bool iDelete = false;
    
    			var removedWreck = new MyWreck();
    
    			for (int i = 0; i < itemCount; i++)
    			{
    				if (items[i].Id == itemidnotodelete)
    				{
    					iDelete = true;
    					removedWreck = items[i];
    
    				}
    				if (iDelete)
    				{
    					if (i < itemCount - 1)
    					{
    						items[i] = items[i + 1];
    					}
    					else
    					{
    						items[i] = removedWreck;
    					}
    				}
    			}
    		}
    	}
