    // This passes all tests
    public static bool Contains(Node root, int value)
    {        
	
		var result = false;
		
		if (root == null) return result;
	
	    if (value == root.Value) 
		{
			result = true; 
		}
		else
		{
			if(value <= root.Value)
			{
			   	if(Contains(root.Left, value))
				{
					result = true;
				}							
			}
			else
			{
				return Contains(root.Right, value); 
			}					
		}
		
		return result;
		
    }
