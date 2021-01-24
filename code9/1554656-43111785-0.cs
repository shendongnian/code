    public static void Main() {
    	
        const int elementsPerRow = 5;
        var data = new [] {"A", "B", "C", "D", "E", 
    					   "F", "G", "H", "I", "J", 
    					   "K", "L", "M", "N", "O", 
    					   "P", "Q", "R", "S", "T"
    	                  };
    		
    	var aIndex = GetIndex(0, 0, elementsPerRow);
    	var eIndex = GetIndex(0, 4, elementsPerRow);
    	var pIndex = GetIndex(3, 0, elementsPerRow);
    	var tIndex = GetIndex(3, 4, elementsPerRow);
    	Console.WriteLine(data[aIndex]); // A
    	Console.WriteLine(data[eIndex]); // E
    	Console.WriteLine(data[pIndex]); // P
    	Console.WriteLine(data[tIndex]); // T
    }
    	
    public static int GetIndex(int rowIndex, int columnIndex, int elementsPerRow) {
    	var index = rowIndex * elementsPerRow + columnIndex;
    	return index;
    }
