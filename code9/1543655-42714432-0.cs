    public void AddPole(GameObject floor, GameObject pole)
    	{
    		var enumerator = polesAttachedToFloor.GetEnumerator ();
    		for (int i = 0; i <= 4; i++)
    		{
    			if (enumerator.MoveNext ()) {
    				var item = enumerator.Current;
    			}
    		}
    
    	}
